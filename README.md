
# Redit2

This is a 3rd-semester assignment, heavily inspired by Reddit. 

It consist of a frontend made with a Blazor-server app, a Web API, and a database, where is used Entity Framework Core and SQLite

## Tech Stack

 Blazor, .NET, C#, Entity Framework, SQLite




## Screenshots

![App Screenshot](https://github.com/fonCki/Reddit2/blob/11e0f478c87ce62d97ee8138e676cb39af0979c5/ScreenShots/File00001.png)
![App Screenshot](https://github.com/fonCki/Reddit2/blob/11e0f478c87ce62d97ee8138e676cb39af0979c5/ScreenShots/File00002.png)
![App Screenshot](https://github.com/fonCki/Reddit2/blob/11e0f478c87ce62d97ee8138e676cb39af0979c5/ScreenShots/File00003.png)


## API Reference

#### Post a comment

```http
  POST /Comments​/Posts​/{UID}​/Comments
```


| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `UID`      | `string` | **Required**. Id of the post     |

#### add(num1, num2)

### Posts

##### Get all posts
```http
  GET /Post
```

##### Create a post
```http
  POST /Post
```

##### Get a unique post
```http
  GET /Post/id
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Id`      | `string` | **Required**. Id of the post      |



### Users

##### Get all users
```http
  GET /Post
```

##### Create a user
```http
  POST /User
```

##### Update a user
```http
  PATCH /User
```

##### Get a unique user
```http
  GET /User/User?email={email}
```



| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `email`   | `string` | **NOTRequired**. the user's email.|




## Authors

- [Alfonso Ridao](https://alfonso.ridao.ar)
- For support, email alfonso@ridao.ar.


## 🚀 About Me
I'm a time traveler

