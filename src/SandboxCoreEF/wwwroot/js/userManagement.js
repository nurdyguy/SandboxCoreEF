
var $dragging;
$(document).ready(function ()
{
    $('.userContainer').on('click', '.user', function ()
    {
        $(this).toggleClass('selected');
   
        //$dragging = $(this).closest('div.userContainer').find('div.user.selected');
    }).sortable(
    {
        connectWith: "div.userContainer",
        delay: 150, //Needed to prevent accidental drag when trying to select
        revert: 0,
        helper: function (e, item)
        {
            //Basically, if you grab an unhighlighted item to drag, it will deselect (unhighlight) everything else
            if (!item.hasClass('selected'))
            {
                item.addClass('selected').siblings().removeClass('selected');
            }

            //////////////////////////////////////////////////////////////////////
            //HERE'S HOW TO PASS THE SELECTED ITEMS TO THE `stop()` FUNCTION:

            //Clone the selected items into an array
            var elements = item.parent().children('.selected').clone();

            //Add a property to `item` called 'multidrag` that contains the 
            //  selected items, then remove the selected items from the source list
            item.data('multidrag', elements).siblings('.selected').remove();

            //Now the selected items exist in memory, attached to the `item`,
            //  so we can access them later when we get to the `stop()` callback

            //Create the helper
            var helper = $('<div/>');
            
            return helper.append(elements);
        },
        stop: function (e, div)
        {
            //Now we access those items that we stored in `item`s data!
            var elements = div.item.data('multidrag');
            elements.addClass('changed');

            //`elements` now contains the originally selected items from the source list (the dragged items)!!

            //Finally I insert the selected items after the `item`, then remove the `item`, since 
            //  item is a duplicate of one of the selected items.
            
            div.item.after(elements).remove();
            
            // make all unselected
            $('.user.selected').removeClass('selected');
        }

    });

    $('#SaveUserRoles').on('click', function ()
    {
        var newRoles = {
            'NewOwners': [],
            'NewAdmins': [],
            'Newusers': []
        };
        $('#owners').find('div.user.changed').each(function ()
        {
            newRoles['NewOwners'].push($(this).data('userid'));
        });
        $('#admins').find('div.user.changed').each(function ()
        {
            newRoles['NewAdmins'].push($(this).data('userid'));
        });
        $('#users').find('div.user.changed').each(function ()
        {
            newRoles['Newusers'].push($(this).data('userid'));
        });

        ShowWaitingOverlay();
        $.ajax({
            type: 'POST',
            url: '/Account/UpdateUserRoles',
            traditional: true,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(newRoles),
            success: function ()
            {
                //notificationMessage("Success!!", "success"); ResetFullPageAfterAction();
            },
            error: function (e1, e2, e3)
            {
                //notificationMessage("Something went wrong resending all invites: " + e1 + " " + e2 + " " + e3, "error");
            },
            complete: function()
            {
                HideWaitingOverlay();
            }
        });
    });
});