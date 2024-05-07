 $(document).ready(function () {
     LoadStages()
 });

 function LoadStages(){
     
     $.ajax({
         url: "http://localhost:5101/api/Stage/GetAll",
         type:'GET',
         dataType : 'json',
         success: function (response) {
             if (response.success) {
                 response.data.forEach(function (stage) {
                     $('#stageGrid tbody').append(`
                         <tr>
                             <td>${stage.stageName}</td>
                                     <td>${stage.stageDescription}</td>
                                     
                         </tr>
                     `)
                 });
             }
         },
         error: function (xhr, status, error) {
             // Check if there is a responseText available
             if (xhr.responseText) {
                 try {
                     // Parse the responseText into a JavaScript object
                     var errorResponse = JSON.parse(xhr.responseText);

                     // Check the properties of the errorResponse object
                     if (errorResponse && errorResponse.message) {
                         // Display the error message to the user
                         alert('Error: ' + errorResponse.message);
                     } else {
                         // Display a generic error message
                         alert('An error occurred. Please try again.');
                     }
                 } catch (parseError) {
                     console.error('Error parsing response:', parseError);
                     alert('An error occurred. Please try again.');
                 }
             } else {
                 // Display a generic error message if no responseText is available
                 alert('An unexpected error occurred. Please try again.');
             }
         },

     });
 }