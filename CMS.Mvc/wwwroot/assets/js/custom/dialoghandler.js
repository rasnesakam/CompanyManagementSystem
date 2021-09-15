// dialog handler shit

function openDialog(link,title){
    $('#dialog-body').html('');
    $('#dialog-title').text(title);
    $('#dialog-body').load(
        link, ()=>{ $('#dialog-modal').modal({show:true}); }
    );
}

$('.dialog-link').on('click',function(){
    var href = $(this).data('href');
    var title = $(this).data('title');
    openDialog(href,title);
})