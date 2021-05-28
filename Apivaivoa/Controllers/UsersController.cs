using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardVaiVoa.Models;
using CardVaiVoa.RuleDomain;
using CardVaiVoa.Repository;

namespace CardVaiVoa.Controllers
{
    [Route("api/v1/cardvaivoa")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Context _context;
        private readonly CreateCard _createCard;
        private readonly UserRepository _userRepository;
        private readonly UserCardRepositoy _userCardRepository;
        private readonly AssociateCard _associateCard;

        public UsersController(
            Context context,
            CreateCard createCard,
            UserRepository userRepository,
            AssociateCard associateCard,
            UserCardRepositoy userCardRepository
          )
        {
            _context = context;
            _createCard = createCard;
            _userRepository = userRepository;
            _userCardRepository = userCardRepository;
            _associateCard = associateCard;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        // POST: api/v1/register
        [HttpPost]
        [Route("register")]            
        /// <summary>
        /// Authenticate route.
        /// </summary>
        /// <param name=""></param>
        /// <returns>Return ok status code 200</returns>
        public async Task<string> PostUserAndCreateCard([FromBody] User user)
        {
            User userBanc = _userRepository.CreateUserForEmail(user.Email);
            var userCard = _associateCard.CreateAndAssociateCard(userBanc.Email);     
            return JsonSerializer.Serialize(userCard);
        }

        // POST: api/v1/list-cards
        [HttpPost]
        [Route("list-cards")]
        /// <summary>
        /// Authenticate route.
        /// </summary>
        /// <param name=""></param>
        /// <returns>Return ok status code 200</returns>
        public async Task<string> PosListCards([FromBody] User user)
        {          
            var result = _userRepository.GetUserForEmail(user.Email);
            var results = _userCardRepository.ListForId(result.Id);  
            return JsonSerializer.Serialize(results);
        }   

   
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
