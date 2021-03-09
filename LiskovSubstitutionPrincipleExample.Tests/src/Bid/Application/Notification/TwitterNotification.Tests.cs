using System;
using Xunit;
using Newtonsoft.JsonResult;
using Newtonsoft.Json;
using LiskovSubstitutionPrincipleExample.src.Bid.Domain;
using LiskovSubstitutionPrincipleExample.src.Bid.Application.Notification;
using LiskovSubstitutionPrincipleExample.src.Bid.Infrastructure;

namespace LiskovSubstitutionPrincipleExample.Tests.src.Bid.Application.Notification
{
        public class TwitterNotification_SuiteTests
        {
            [Fact]
            public void Should_Send_Notification_To_Twitter() 
            {
                #region Prepare test
                string expectedValue = "Hello World";
                TwitterNotifier  tweet = new TwitterNotifier(
                    "Hello World",
                    "eLtPJr6q05xdxFkm5bfRH1T0O",
                    "XfdqGUd7a7w5286ECumfSjdJrr0NxMPKQjnPuvhPMCAMQMCtEi", 
                    "223567944-KbEESnkippAyYhmDNOg05e5gPH91Owx49ZKqlCtD",
                    "BO05Xa1fYai80TD1F3gpSd9ayCMS9sGfYFVJ6NlpqV9Gx"
                );
                #endregion

                #region Execute test
                TwitterNotification sendNotification = new TwitterNotification();
                JsonResult notificationResponseMessage = sendNotification.Send(tweet);
                var result = (Tweet)notificationResponseMessage.Data;
                #endregion
                #region Check test
                Assert.Equal(expectedValue,result.Text);
                #endregion
            }
        }
}