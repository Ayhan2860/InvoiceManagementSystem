let selectedDate = () =>
{
     let newDate = new Date;
     let date  = newDate.getDate();
     let month = newDate.getMonth() + 1;
     let year = newDate.getFullYear();

    if(date < 10)
      date = '0' + date
    if(month < 10)
      month = '0' + month;
    
    return   `${month}/${date}/${year}`;

} 
let formatedDate = selectedDate();

$('.result').val(formatedDate)
$(".datepicker").click(function (e) {
     if($(e.target).data('day') != null)
     {
           
          $('.result').val($(e.target).data('day'))
     }
})


