# TstDB_API
Database &amp; API service for StreamAuctioneer

### Authentication:
    User (pwd) -> Client
    Client (pwd) -> Auth Server
    Client <- (token) Auth Server
    User <- (token) Client
  
### Authorization (Get Resource):
    User (token) -> Resource Server
    User <- (resource) Resource Server

### Oauth:
    OWIN middleware component that handles the details of OAuth2
