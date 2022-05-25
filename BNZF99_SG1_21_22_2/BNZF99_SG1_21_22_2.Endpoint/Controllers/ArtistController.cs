using BNZF99_SG1_21_22_2.Logic.Interfaces;
using BNZF99_SG1_21_22_2.Models.DTOs;
using BNZF99_SG1_21_22_2.Models.Entities;
using BNZF99_SG1_21_22_2.Models.Enums;
using BNZF99_SG1_21_22_2.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BNZF99_SG1_21_22_2.Endpoint.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        readonly IArtistLogic artistLogic;

        public ArtistController(IArtistLogic artistLogic)
        {
            this.artistLogic = artistLogic;
        }

        // GET: api/Artist/GetAll
        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<Artist> Get()
        {
            return artistLogic.ReadAll();
        }

        // GET api/Artist/Get/5
        [HttpGet("{id}")]
        public Artist Get(int id)
        {
            return artistLogic.Read(id);
        }

        // POST api/Artist
        [HttpPost]
        [ActionName("Create")]
        public ApiResult Post(ArtistDTO artist)
        {
            var result = new ApiResult(true);

            try
            {
                artistLogic.Create(new Artist()
                {
                    Id = artist.Id,
                    Name = artist.Name,
                    Born = artist.Born,
                    RecordLabel = artist.RecordLabel,
                    Instrument = artist.Instrument,
                    IsOnRehab = artist.IsOnRehab,
                    EndOfContract = artist.EndOfContract
                });
            }
            catch (Exception ex)
            {
                result.IsSuccessful = false;
                result.Messages = new List<string> { ex.Message };
            }

            return result;
        }

        // PUT api/Artist/Update
        [HttpPut]
        [ActionName("Update")]
        public ApiResult Put(ArtistDTO artist)
        {
            var result = new ApiResult(true);

            try
            {
                artistLogic.Update(new Artist()
                {
                    Id = artist.Id,
                    Name = artist.Name,
                    Born = artist.Born,
                    RecordLabel = artist.RecordLabel,
                    Instrument = artist.Instrument,
                    IsOnRehab = artist.IsOnRehab,
                    EndOfContract = artist.EndOfContract

                });
            }
            catch (Exception ex)
            {
                result.IsSuccessful = false;
                result.Messages = new List<string> { ex.Message };
            }

            return result;
        }

        // DELETE api/Artist/5
        [HttpDelete("{id}")]
        public ApiResult Delete(int id)
        {
            var result = new ApiResult(true);

            try
            {
                artistLogic.Delete(id);
            }
            catch (Exception ex)
            {
                result.IsSuccessful = false;
                result.Messages = new List<string> { ex.Message };
            }

            return result;
        }

        [HttpGet]
        public IEnumerable<Instruments> GetAllInstruments()
        {
            return (Instruments[])Enum.GetValues(typeof(Instruments));
        }
    }
}
