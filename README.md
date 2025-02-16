# BeoRecruitment
The purpose of this project is to facilitate a technical interview of potential new hires to Bang & Olufsen A/S.

Please read the assignement and make sure you understand it. If you have any questions, please reach out to Martin (malo@bang-olufsen.dk).

# The Assignment
Build a small app in MAUI that allows the user to search for artists on Spotify.

We imagine a search input field and a presentation of the search results.
    
>**How to present the results is up to you.**

Provided here is a dotnet solution that provides the most basic plumming such as navigation and IoC. The idea is for you to spent more time coding the assignment using less time on the trivial stuff. If you prefer other frameworks, feel free to use them.

# The Focus
When evaluating your submission, we would like to see e.g.
* Structured code
* Usage of git
* Design principles (e.g. MVVM and S.O.L.I.D.)
* Object oriented programming principles e.g. encapsulation, inheritance, polymorphism and abstractions 
* Using different modern aspects of the C# language

# The Extra
Decorating the result with images and extra information would be cool. Remember we like responsive UI so loading of images should not be blocking.

Having a details page showing further information of an artist. This could be e.g. a list of albums of just plain details of the artist.

Opening the Spotify app when selecting an item/artist. This can be achieved using e.g. `spotify:artist:4aaBjq7VqqQvpSF69GglvO` 

# The Corners to Cut
Even though we prefer an app that works for both platforms, we do accept that only one platform fully works. However, code must be written to be cross platform compatible.

Looks isn't everything and that is also the case here. We would rather see a working app with a few UI flaws than a perfect looking UI that does not work. Obvisoulsy, we at Bang & Olufsen, strive to make things look good - working from our strategi: Luxury Timeless Technology.

# The Spotify Access
To access Spotify, you need to register your app. This can be done here: https://developer.spotify.com/documentation/web-api/concepts/apps  
After registering your app, you will have access to a client id and secret.

We have already done this for you. You can use these values:

    Client ID:     aae368d1daac4561af4600d1bfeb3a4f
    Client secret: c7a7b72a78104a49a607b2480cbb8587

Before you can access the Spotify rest api, you must first authenticate. You need the client id and secret and base64 encode them:

    base64("clientid:secret")

Example:

    base64("aae368d1daac4561af4600d1bfeb3a4f:c7a7b72a78104a49a607b2480cbb8587")

This is a working example using curl of how to get the authorization token:

    curl --request "POST" --header "Authorization: Basic YWFlMzY4ZDFkYWFjNDU2MWFmNDYwMGQxYmZlYjNhNGY6YzdhN2I3MmE3ODEwNGE0OWE2MDdiMjQ4MGNiYjg1ODc" --data "grant_type=client_credentials" https://accounts.spotify.com/api/token


Once you receive the authorization token, you can utilize the rest api like this:

    curl --request GET --header "Authorization: Bearer [token]" "https://api.spotify.com/v1/search?q=moloko&type=artist"

# The Documentation
For further information on the Spotify API, please go to  
https://developer.spotify.com/documentation/web-api/concepts/api-calls

Searching is described here:  
https://developer.spotify.com/documentation/web-api/reference/search

Getting artist detailed information can be found here:  
https://developer.spotify.com/documentation/web-api/reference/get-an-artist
