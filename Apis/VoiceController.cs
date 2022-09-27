using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using call_replay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace call_replay.Apis
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoiceController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public VoiceController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> RespondToVoice()
        {
            var rand = new Random().Next(_dbContext.WishLogs.Count());
            var randomWish = _dbContext.WishLogs.AsEnumerable().ElementAt(rand);

            var basePath = new Uri($"{Request.Scheme}://{Request.Host.Value}/{randomWish.AudioFileUrl}");
            var response = new VoiceResponse();
            response.Say($"Here is a wish from {randomWish.PersonWishing}", voice: "alice");
            response.Play(basePath);

            return new TwiMLResult(response);
        }
    }
}