To test with ngrok drop to the command line and execute:

ngrok http 52280 -host-header="localhost:52280" -subdomain=whetstone


If the Web API project launches in debug mode to another port, substitute that port for 52280.

If ngrok is not installed on the local machine, download it and create a new account on ngrok.com if necessary.

https://ngrok.com/

netsh http add urlacl url=https://whetstone.ngrok.io:52280/ user=everyone

