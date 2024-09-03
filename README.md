# load-testing

## Building Endpoints
All files inside ``functions/`` can be pasted into ``wwwroot/`` via Kudu to build a function app with an HTTP trigger and a non-HTTP queue trigger.
All files inside ``webapps/`` can be pasted into ``wwwroot/`` via Kudu to build a web app with an HTTP endpoint. 
``webapps.cs`` is the raw code for the actual web application that turned into the files inside ``webapps/``. 

## Sending Traffic
Each trigger type has a corresponding file in ``consoleapps/`` that can be directly pasted into ``Program.cs`` for any console applications to start sending traffic.

## Small Setup Things
Remember to add relevant app settings, like ``FUNCTIONS_EXTENSION_VERSION`` and ``AzureWebJobsStorage`` (allow access to storage accounts).
