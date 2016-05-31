﻿
//$(selector)
//JSON location : contoller/actionName
//URL(specifies the url to send the request to), data (specifies data to be sent to the server), sucess(if the request is sucedded run)
//Load data from the server using GET HTTP request
//$(selector).getJSON(url,data,success(data). The last parameter(data) contains the data returned from the server.
//Plain object (in the array) (senderID,roomId,recipentid)
//Null = vi skal ikke sende noget brugerId afsted? 
//Selector!
//if confirmed then we are posting our data to the server for validating.

$.getJSON("/Invite/findInvitesForOnePerson", null, function (data)
{
    console.log(data);
    if(data.length > 0)
    {
        if (confirm("Du er blivet inviteret til et rum. Vil du deltage?"))
        {
            $.post("/invite/acceptInvite", data[0], function ()
            {
                console.log("Invitiation er accepteret");

            })
        }



    }



})