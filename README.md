[![Build Status](https://ivanpenadev.visualstudio.com/TechTestApi/_apis/build/status/TechTestApi-CI?branchName=master)](https://ivanpenadev.visualstudio.com/TechTestApi/_build/latest?definitionId=3&branchName=master)

# Technical Test API

This is a small Web API created as part of a Technical Test.\
Live URL: https://ivan-techtestapi.azurewebsites.net/api/app

## Contents

- [Prerequisites](#prerequisites)
- [Deployment](#deployment)
- [How To Use](#how-to-use)
- [Associated Risks](#associated-risks)


Prerequisites
-------------

1. Depending on the OS, one of the following:
  * Linux based OS - Docker Engine
  * Mac or Windows 10 Pro - Docker Desktop
  * Windows 10 Home and older versions - Docker Toolbox

Deployment
----------

Notes about how to deploy the web API on a live system:

1. Get the source code from here (```https://github.com/irpenha/techtestapi```) and drop it into a folder of your preference. As an example, we will call the folder ```C:\root```.
1. Start Docker Engine/Desktop.
1. Using the command line, go to ```C:\root\TechTestApi```.
1. Execute ```docker build -t techtestapi_image .``` to build the image.
1. Once the image is done, execute ```docker run -p 4000:80 --name apicontainer techtestapi_image``` to run the container which will be called "apicontainer".
1. Using a web browser, navigate to ```http://localhost:4000/api/app``` and you should see a ```Hello World``` on the screen. If you are using Docker Toolbox on Windows 10 Home Edition or older versions, use the Docker Machine IP instead of ```localhost```. For example, ```http://192.168.99.5:4000/```. To find the IP address, use the command ```docker-machine ip```.

How To Use
----------

Currently the API only have three endpoints implemented:

### 1. Application Root

This endpoint can be accessed through:

* ```{protocol}://{domain_name}/api/app```
* ```{protocol}://{domain_name}/api/app/root```

You should then see ```Hello World``` as the result.

### 2. Application Health

This endpoint can be accessed through:

* ```{protocol}://{domain_name}/api/app/health```
* ```{protocol}://{domain_name}/api/app/health/{status}```

```{status}``` can be any of 4 different string values (case insensitive), each one of them resulting in it's corresponding numeric status code:

1. OK - ```Status Code: 200``` - OK
1. BAD - ```Status Code: 400``` - Bad Request
1. ERROR - ```Status Code: 500``` - Internal Server Error
1. PIRATE - ```Status Code: 401``` - Unauthorized

Any other value will return ```Status Code: 404``` (Not Found).

### 3. Application Info

This endpoint can be accessed through:

* ```{protocol}://{domain_name}/api/app/info```

The result will be a JSON object as the one depicted below:

```json
{
  "name":"MyApplication",
  "version":1.0,
  "description":"Pre-interview technical test"
}
```

Associated Risks
----------------

* The web API doesn’t have any sort of authentication or role-based access implemented, which pose a security risk as every single user, allowed or not allowed, will have access to every single endpoint.
* The web API doesn’t implement any sort of mechanism to return user friendly errors, which could make the app less engaging to users.
* Thw web API doesn’t implement any sort logging of errors and/or warnings, which could keep issues in the dark living in the app indefinitely. 
* During deployment, the web API could require dependencies not available in the target machine which will render it completely unusable and useless.
