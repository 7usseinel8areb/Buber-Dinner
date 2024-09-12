# Buber Dinner API
- [Buber Dinner API](#buber-dinner-api)
	- [Auth](#auth)
		- [Register](#register)
			- [Register Request](#register-request)
			- [Register Response](#register-response)
		- [Login](#login)
			- [Login Request](#login-request)
			- [Login Response](#login-response)
		
## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
	"firstName": "Hussein",
	"lastName": "Elghareb",
	"email": "halghryb287@gmail.com",
	"password": "hussein1232!"
}
```

#### Register Response

```js
200 OK
```

```json
{
	"id": "nndsk99-nkdn23-sdnnso-nekek222w33",
	"firstName": "Hussein",
	"lastName": "Elghareb",
	"email": "halghryb287@gmail.com",
	"token": "knkndknknksmsjoweiende238b"
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
	"email": "halghryb287@gmail.com",
	"password": "hussein1232!"
}
```

#### Login Response

```js
200 OK
```

```json
{
	"id": "nndsk99-nkdn23-sdnnso-nekek222w33",
	"firstName": "Hussein",
	"lastName": "Elghareb",
	"email": "halghryb287@gmail.com",
	"token": "knkndknknksmsjoweiende238b"
}
```