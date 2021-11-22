#!/bin/bash
docker build -t c3p-notification-api:1.0 .
docker run -d -p 9094:80 --name notification-api c3p-notification-api:1.0
read -p "Press enter to continue"