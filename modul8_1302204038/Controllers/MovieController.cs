using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace modul8_1302204038.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private static List<string> Stars1 = new List<string>
        {
             "Elijah Wood", "Viggo Mortensen", "Ian McKellen", "Orlando Bloom"
        };
        private static List<string> Stars2 = new List<string>
        {
           "Leonardo DiCaprio", "Joseph Gordon-Levitt", "Elliot Page", "Ken Watanabe"
        };
        private static List<string> Stars3 = new List<string>
        {
           "Matthew McConaughey", "Anne Hathaway", "Jessica Chastain", "Mackenzie Foy"
        };
        private readonly ILogger<MovieController> _logger;
        List<Movie> movies3 = new List<Movie>();
        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            movies3.Add(new Movie("The Lord of the Rings: The Return of the King ", "Peter Jackson ", Stars1, "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring"));
            movies3.Add(new Movie("Inception", " Christopher Nolan", Stars2, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster"));
            movies3.Add(new Movie("Interstellar", "Christopher Nolan", Stars3, "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival"));
            return movies3.ToArray; 
        }

        [HttpGet("{id}")]
        public Movie GetMovieById(int id)
        {
            var moviedata = this.movies3.ElementAt(id - 1);
            if (moviedata != null) return null;
            return moviedata;
        }

        [HttpPost]
        public IEnumerable<Movie> Post([FromBody] Movie movie)
        {
            movies3.Add(new movie(movie.Title, movie.Director, movie.Stars, movie.Description));
            return movies3;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
