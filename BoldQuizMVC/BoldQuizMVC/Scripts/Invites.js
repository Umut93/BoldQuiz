﻿
//$(selector)
//JSON location : contoller/actionName
//URL(specifies the url to send the request to), data (specifies data to be sent to the server), sucess(if the request is sucedded run)
//Load data from the server using GET HTTP request
//Null = vi skal ikke sende noget brugerId afsted? 
//Selector!

$.getJSON("Invite/findInvitesForOnePerson", null, function (data)
{
    console.log(data);
    if(data.length > 0)
    {
        confirm("Du er blivet inviteret til et rum. Vil du deltage?")

    } 

})