[![Build Status](https://ivanpenadev.visualstudio.com/TechTestApi/_apis/build/status/TechTestApi-CI?branchName=master)](https://ivanpenadev.visualstudio.com/TechTestApi/_build/latest?definitionId=3&branchName=master)

# Technical Test API

This is a small Web API created as part of an MYOB Pre-Interview Technical Test.

## Contents

- [Prerequisites](#prerequisites)
- [Deployment](#deployment)
- [How To Use](#how-to-use)


Prerequisites
-------------

What things you need to install the software and how to install them

Deployment
----------

Add additional notes about how to deploy this on a live system

How To Use
----------

Currently the API only have three enpoints implemented:

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

### 3. Appication Info

This endpoint can be accessed through:

* ```{protocol}://{domain_name}/api/app/info```

The result will be a JSON object as the one depicted below:

```json
[
  {
    "name":"MyApplication",
    "version":1.0,
    "description":"Pre-interview technical test"
  }
]
```
