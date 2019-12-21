// Movies on Flight
// You are on a flight and wanna watch two movies during this flight.
// You are given int[] movie_duration which includes all the movie durations.
// You are also given the duration of the flight which is d in minutes.
// Now, you need to pick two movies and the total duration of the two movies is less than or equal to (d - 30min).
// Find the pair of movies with the longest total duration. If multiple found, return the pair with the longest movie.
//
// e.g.
// Input
// movie_duration: [90, 85, 75, 60, 120, 150, 125]
// d: 250
//
// Output from aonecode.com
// [90, 125]
// 90min + 125min = 215 is the maximum number within 220 (250min - 30min)




let d = 250;
let md = [90, 85, 75, 60, 120, 150, 125];

//---------------------------------
let rd = d - 30;

let bestlenght = 0;
let bestmatch = [];
let summovies = 0;

for(let i = 0; i < md.length; i++)
{
  for(let j = 0 ; j < md.length; j++)
  {
    summovies = md[i] + md[j];
    if( summovies <= rd && summovies > bestlenght )
    {
      bestlenght = summovies;
      bestmatch[0] = md[i];
      bestmatch[1] = md[j];
    }
  }
}

console.log('best match: '+ bestmatch[0] + ' , ' + bestmatch[1] + ' - with a length of: ' + bestlenght );
