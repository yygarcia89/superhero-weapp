# SuperHero App

## Description
SuperHero app is a responsive web application based on SuperHero API to search for Super Heroes and Villains from all universes. 

## TechStack
* Backend: MVC .Net, Azure Redis Cache
* Frontend: Bootstrap 4, Font-Awesome, Jquery

## Installation
* Clone repository
* Update "SuperHeroAPIBaseUrl" setting on web.config to use your own API BaseUrl with your auth token
* Update "RedisEndpoint" setting on web.config to use your own Azure Redis server
* Install dependencies by using the Nuget Package Manager
* Run the app

## Usage
* Search component: type the word(s) you want to search for a hero/villain. Press "Enter" or click on the "Search" button. The app will try to request data from cache, if not found, a request will be triggered to SuperHEro API, and then, results are saved on Redis Cache for future use.
* Profile page: after search results, click on "Explore" on a hero/villain result item to be redirected to the profile page in order to check the character's information.

## Note
* In order to optimize cache bandwith and space, data if compressed before saved on cache, and decompressed after retrieved from cache. 
* To avoid 404-images with character's profile-card, a javascript code is added to handle 404-error on html-img items, and replace content with a local resource. 
