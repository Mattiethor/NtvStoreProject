# FakeStoreProject
# FakeStoreProject API

Made in [ASP.net](http://ASP.net) using EF core. 

Used together with https://github.com/Mattiethor/FakeStoreVue

## Reference:

This Database relationship chart was used to make this project. 

[https://www.sqlservertutorial.net/sql-server-sample-database/](https://www.sqlservertutorial.net/sql-server-sample-database/)
![image](https://user-images.githubusercontent.com/82813440/172060019-e9e2d97d-2a01-4d87-bc8f-43eb4008e549.png)
![image](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/ccaa6d54-6886-4614-a336-3666eab01fec/Untitled.png)

## Example in swagger:



![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/65e1c97e-9016-4686-8ad3-715badb593a4/Untitled.png)

![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/21bf6be4-8959-4e64-b117-3a6088dd8558/Untitled.png)

### if you plan on using for personal use you have to change the Origin to your allowed origin:

builder.Services.AddCors(options =>
{
options.AddPolicy(name: MyAllowSpecificOrigins,
policy =>
{
//Add your own origin for frontend use.
policy.WithOrigins(**"http://localhost:8080"**
);
});
});
