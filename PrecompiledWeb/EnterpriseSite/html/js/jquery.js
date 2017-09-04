$(function(){

	// 焦点图轮播
	var index=0;
	var index_len=$('.article_pic a').length;
	// console.log(index_len);

	var index_num='';
	for(var i=0;i<index_len;i++){
		index_num=index_num+'<b></b>';
		// console.log(i);
	}
	$(index_num).appendTo('.article_nav');
	tabs(index);
	function tabs(index){
		$('.article_pic a').eq(index).fadeIn(200).siblings().fadeOut(200);
		$('.article_nav b').eq(index).css('background','#c41e1f').siblings().removeAttr('style');
		$('.article_word span').eq(index).show().siblings().hide();
	}
	var myan=setInterval(function(){
		tabs(index);
		index++;
		if(index>index_len)
			index=0;
	},3000);

	$('.article_pic').hover(function(){
		clearInterval(myan);
	},function(){
		myan=setInterval(function(){
		tabs(index);
		index++;
		if(index>index_len)
			index=0;
	},3000);
	});

	$('.article_nav b').hover(function(){
		index=$(this).index();
		tabs(index);
		clearInterval(myan);

	},function(){

		myan=setInterval(function(){
		tabs(index);
		index++;
		if(index>index_len)
			index=0;
	},3000);
	});
//微信底部固定

var window_h=$(window).width();
var window_left=(window_h-1360)/2;
console.log(window_h+'  右边 '+window_left);
if (window_h<1280) {
	$('.weixin').css('display','none');
}
else{
	$('.weixin').css({
		'display':'block',
		'right':window_left
	});
}	


});