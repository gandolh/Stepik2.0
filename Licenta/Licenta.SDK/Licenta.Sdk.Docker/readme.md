
# keycloak

To use keycloak ( maybe use robotic process automation for configuration).

Create a realm named test-realm-1.
Create a client called myclient with clientId "myclient", activate client authentication, check implicit flow, choose login theme as keycloak.
Web origins / valid redirect uri to "*" for local debug.
Root url: http://127.0.0.1:8080/
Home url: Your app url from visual studio
Save

Add keycloak name resolution to point to 127.0.0.1 in hosts in windows.



# postgres

server: postgres
port: 5432
user: admin, pw: admin -> for db
connection string: Provider=PostgreSQL OLE DB Provider;Data Source=myServerAddress;location=myDataBase;User ID=myUsername;password=myPassword;timeout=1000;

# beaver 
user: cbadmin, pw: admin