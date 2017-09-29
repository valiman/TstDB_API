# TstDB_API
Database &amp; API service for StreamAuctioneer

### Authentication:
    User (pwd) -> Client
       body:   x-www-form-urlencoded 
                grant_type: password
                username: em@ail.com
                password: *******
    
    Client (pwd) -> Auth Server
    Client <- (token) Auth Server
        returns a token, save in session
    User <- (token) Client
  
### Authorization (Get Resource):
    User (token) -> Resource Server
        header: Authorization:  Bearer <token>
    User <- (resource) Resource Server
        returns valid resource if all ok!
        
### Oauth:
    OWIN middleware component that handles the details of OAuth2

### Note: 
    (HTTP Response) You must use HTTPS to provide transport layer security.
