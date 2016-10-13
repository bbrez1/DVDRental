******************************************************************
My CV link: https://dl.dropboxusercontent.com/u/2611010/Resume.pdf
******************************************************************

Before I began I estimated that this project would take ~20 to have a decent / bug free version with all the requirements met (written in previous SQL related task).
So I had to strip it down a bit. Obviously I could finish it quicker if I wanted a very simple -> default bootstrap design and razor powered solution (not powered by js). I wanted it to be "modern".

I decided to write a limited project that focused on a good UI and using a mix of different techniques / external libraries to show as much as I can of what I know.
I left out tasks that were very basic and didn't express any special skills (forms for entering new users or updating them are very basic; time consuming to setup validation and 
everything but everyone can do that)

I didn't mind about writing titles for pages; repeating or writing too many code comments; writing tests; setting up https <- obviously all these are very important in a production environment; 
again - 4 hours is not a lot of time

I spent around 4 hours and 30 minutes on this project.

Things I wanted to do and focused on:

- Overview of all movies that are available and how many copies there are
- Overview of all movies rented / all movies rented by each customer
- Decent user experience (added infinite scroll on movies; js powered movie selection and confirming the rentals)


Things I had to leave out:

- Inserting / Updating customers - frontend (the backend functionality is still there tho; I used an API to generate random user information - more on this below.
								  The reason I left this out is because it can be time consuming and most of the task here is just frontend stuff - 
								  creating input fields and validating input which is very basic stuff;)

- Inserting / Updating movies - frontend (auto generated this data by screen scraping it; again the backend code is here again)

- Stock monitoring is there but Oscar can't enter how many values he has of each (again - just forms; the numbers are generated and if no copy of each movie is available Oscar will see this)
Also Oscar could also rent out DVD, BluRay, 4K copies of each movie. I just assumed he rents out only DVDs (for simplicity).


Technologies / Plugins / External Libraries / Apis / .....     used:

-   Bootstrap (obviously since its used as a default framework;)
-   Console app to screen scrape data
-	Google fonts (wanted a nicer font)
-	Htmlagilitypack (for screen data scraping)
-   namefake.com api to generate random customers
-	Json.net to convert json from above (namefake api) to objects
-	angularjs and plugins (infinite scroll and masonry) to add infinite scrolling of movies and to add 
-	I used both angular and standard .net controllers with Razor (to show Razor is simple aswell and that I'm not an angular fanboy)
-	mongodb (I was torn apart between using MySQL or MongoDB here. I know MySQL would have been a much better choice since I can't do INNER JOINS in mongo (tho the latest mongo version has them)
			and nosql/document storages are good for projects where we dont know the data structure in advance but the data here is always the same / it has the same structure.
			While I have used both before on many different projects I decided to go with mongo because of the short deadline and since 
			it's much quicker to insert and read data with mongo and use it for prototyping - atleast thats my experience)
-	the obvious ones: html / css / c#



Projects in the solution:




- Data
	+	Includes all classes to insert, read and update data in the database

	- CustomerApi   \
	- MovieApi       | -  all 3 include basic mongo calls to store / update or read data
	- RentalsApi    /

- DVDRental
	+	Web Application

- DVDScraper
	Two functions; Wrote this so I didn't have to manually enter data and to show how easy it is to screen scrape / use APIs

	+	GenerateRandomUsers - uses namefake.com's api to populate our customer data. 

	Explanation of the function:
	Calls the API 20 times to grab info of 20 randomly generated users, deserializes the object and inserts it into the database

	+	GenerateMovies		- screen scrapes themoviedb to gather basic data about movies 
	(didn't find a decent api that was available without waiting for the owners to confirm my account so I just screen scraped it)
	Loads 300 pages of movies and grabs the movie's name, image, description, genre, year of release and adds a random number of how many copies are available.
	I have a bug in this code - it scrapes the same data multiple times on each page so it only inserts one movie per page (so I added a break to just skip it) 
	- wanted to come back to this but ran out of time.

- Models
	+	All data models used with the scrapers / web app - don't think these need explaining




The app is split into 3 different sections or pages:

******************
**** Overview ****

Every dashboard needs a quick overview / homepage page.
The idea of the overview page is that each time Oscar logs in he has an overview of which movies are available and how many copies.
This would be really useful since it's a quick overview and lets Oscar quickly search for a movie and see how many copies there are.

Example uses:
- A customer comes in and wants to know if Oscar has the new Avengers movie available. Oscar can quickly search this up
- A customer finds a movie he likes in Oscar's store. The movie is Jack Reacher and asks for additional info. Oscar can search the movie up and click on it to find more info
about the movie.

Potential improvements: Search bar to filter and find movies by name (I had this planned but left it out since I was running out of time)

*****************
**** Rentals ****

This is a simple overview of all movies rented by customers. It shows what movies each customer rented.

Potential improvements: 

*******************
**** Customers ****

Since it's a good idea that only Oscar can access this dashboard I created the project with user authorization.
I created one account for Oscar (admin@admin.com ; pass: ab123456 which would be used by Oscar)
If this app ever went live I would just disable user registrations for new users (delete or rename the register controller; add a special field that you can only signup with a passcode or similar);
Oscar already has his account so only he can access the backend. All pages require Authentication by users.



DISTRIBUTED TIME:

~ 60 min ( setting up the project, adding angularjs, mongodb, required scripts, etc. )
~ 45 min ( design / css )
~ 60 min ( setting up data models )
~ 90 min ( setting up the apis )
~ 30 min ( screen scraping )


Loved the test, was fun. A bit too big to fully implement in 4 hours.