# IsPremiumMSA
Check if the MSA has premium subscription

# Microsoft Graph API
The graph API https://graph.microsoft.com/v1.0/me/drive sends the response with "upgradeAvailable" true or false depending on the subscription. We can use that API to check if the account is premium.
Try out it https://developer.microsoft.com/en-us/graph/graph-explorer. You have to SignIn and might have to grant permission to read.file in the permissions tab.

# Authentication
To call the Graph API, we need to get access on behalf of user.
See for https://docs.microsoft.com/en-us/graph/auth-v2-user details on how to do that. We will get a refresh token along with the access token and can use that to refresh the access token one it expires.
