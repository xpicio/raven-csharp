﻿#region License

// Copyright (c) 2014 The Sentry Team and individual contributors.
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted
// provided that the following conditions are met:
// 
//     1. Redistributions of source code must retain the above copyright notice, this list of
//        conditions and the following disclaimer.
// 
//     2. Redistributions in binary form must reproduce the above copyright notice, this list of
//        conditions and the following disclaimer in the documentation and/or other materials
//        provided with the distribution.
// 
//     3. Neither the name of the Sentry nor the names of its contributors may be used to
//        endorse or promote products derived from this software without specific prior written
//        permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
// IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System.Threading.Tasks;

using NUnit.Framework;

using SharpRaven.Data;

namespace SharpRaven.UnitTests
{
    [TestFixture]
    public class RavenClientCaptureMessageAsyncTests
    {
        #region SetUp/Teardown

        [SetUp]
        public void SetUp()
        {
            this.tester = new RavenClientTester();
        }

        #endregion

        [Test]
        public void ClientEnvironmentIsIgnored()
        {
            this.tester.ClientEnvironmentIsIgnored(client =>
            {
                client.CaptureMessageAsync("Test").GetAwaiter().GetResult();
            });
        }


        [Test]
        public async Task ClientLoggerIsIgnored()
        {
            this.tester.ClientLoggerIsIgnored(async client => await client.CaptureMessageAsync("Test"));
        }


        [Test]
        public async Task ClientReleaseIsIgnored()
        {
            this.tester.ClientReleaseIsIgnored(async client => await client.CaptureMessageAsync("Test"));
        }


        [Test]
        public async Task InvokesSendAndJsonPacketFactoryOnCreate()
        {
            // this.tester.InvokesSendAndJsonPacketFactoryOnCreate(async client => await client.CaptureMessageAsync("Test"));
        }


        [Test]
        public async Task OnlyDefaultTags()
        {
            this.tester.OnlyDefaultTags(async client => await client.CaptureMessageAsync("Test"));
        }


        [Test]
        public async Task OnlyMessageTags()
        {
            this.tester.OnlyMessageTags(async (client, tags) => await client.CaptureMessageAsync("Test", ErrorLevel.Info, tags));
        }


        [Test]
        public async Task ScrubberIsInvoked()
        {
            this.tester.ScrubberIsInvoked(async (client, message) => await client.CaptureMessageAsync(message));
        }


        [Test]
        public async Task SendsEnvironment()
        {
            this.tester.SendsEnvironment(async client => await client.CaptureMessageAsync("Test"));
        }


        [Test]
        public async Task SendsLogger()
        {
            this.tester.SendsLogger(async client => await client.CaptureMessageAsync("Test"));
        }


        [Test]
        public async Task SendsRelease()
        {
            this.tester.SendsRelease(async client => await client.CaptureMessageAsync("Test"));
        }


        [Test]
        public async Task TagHandling()
        {
            this.tester.TagHandling(async (client, tags) => await client.CaptureMessageAsync("Test", ErrorLevel.Info, tags));
        }


        private RavenClientTester tester;
    }
}