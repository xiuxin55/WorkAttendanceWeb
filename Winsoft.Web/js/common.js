// JavaScript Document
var curMenu = [];

window.addEvent('domready', function(){
	var s_list = $('siteslist');
	if(s_list)
	{
		s_list.fx = new Fx.Slide(s_list);
		s_list.fx.hide();
		
		var s_btn = $('sitesbtn');
		s_btn.addEvent('mouseover', function(evt){
			$('siteslist').fx.slideIn();
		});
		
		var outEvent = function(evt){
			var rel = evt.relatedTarget;
			while(rel.parentNode != document.body && rel.parentNode != null)
			{
				if(rel == $('siteslist') || rel == $('sitesbtn'))
				{
					return;
				}
				rel = rel.parentNode;
			}
			
			$('siteslist').fx.slideOut();
		};
		
		s_btn.addEvent('mouseout', outEvent);
		s_list.addEvent('mouseout', outEvent);
	}
	
	s_list = $('p_siteslist');
	if(s_list)
	{
		s_list.fx = new Fx.Tween(s_list, {
			property: 'margin-top'
		});
		s_list.fx.addEvent('complete', function(){
			if($('p_siteslist').getStyle('margin-top').toInt() >= 89)
			{
				$($('p_siteslist').parentNode).setStyle('visibility', 'hidden');
			}
		});
		
		var s_btn = $('p_sitesbtn');
		s_btn.addEvent('mouseover', function(evt){
			$('p_siteslist').fx.start(0);
			$($('p_siteslist').parentNode).setStyle('visibility', 'visible');
		});
		
		var outEvent = function(evt){
			var rel = evt.relatedTarget;
			while(rel.parentNode != document.body && rel.parentNode != null)
			{
				if(rel == $('p_siteslist') || rel == $('p_sitesbtn'))
				{
					return;
				}
				rel = rel.parentNode;
			}
			
			$('p_siteslist').fx.start(68);
		};
		
		s_btn.addEvent('mouseout', outEvent);
		s_list.addEvent('mouseout', outEvent);
	}
	
	//轮播图
	if($('hotimg_scl'))
	{
		sclSize = $$('.hotimgs')[0].getSize().x;
		resizeScl();
		
		sclFx = new Fx.Scroll($('hotimg_scl'), {
			
		});
		sclFx.addEvent('complete', function(){
			sclFxRunning = false;
			sclIndex++;
			if(sclIndex >= $$('.h_img').length - 1)
			{
				sclIndex = 0;
				$('hotimg_scl').scrollTo(0, 0);
			}
		});
		$('hotimg_scl').scrollTo(0, 0);
		sclFxTimer = sclGo.delay(7000);

		var ps = $$('.hotimgs_preview div.preview');
		for(var i = 0; i < ps.length; i++)
		{
			if(i == 0)
			{
				ps[i].addClass('act');
			}
			else
			{
				ps[i].setStyle('opacity', 0.8);
			}

			ps[i].addEvent('click', (function(evt){
				sclFx.stop();
				try
				{
					clearTimeout(sclFxTimer);
				}
				catch(ex)
				{

				}
				sclIndex = this[1] - 1;
				sclGo();

				

			}).bind([ps[i], i]));
		}
	}

	//顶部菜单特效
	/*
	var mainmenu = $$('.mainmenu');
	if(mainmenu.length > 0)
	{
		mainmenu = mainmenu[0];

		var spans = mainmenu.getElements('span');
		$('hotimg_scl').addEvent('mouseover', function(){
			curMenu.each(function(item){
				item.fx.slideOut();
			});
		});
		for(var i = 0; i < spans.length; i++)
		{
			var id = spans[i].id.substr(7);
			var a = spans[i].getElement('a');
			//var menu = spans[i].getElement('div.dd_menu');
			var menu = $('l_menu_' + id);
			if(menu == null) continue;
			switch(id)
			{
				case 'about':
					menu.setStyle('margin-left', '100px');
					break;
				case 'e2b':
					menu.setStyle('margin-left', '200px');
					break;
				case 'case':
					menu.setStyle('margin-left', '300px');
					break;
				case 'join':
					menu.setStyle('margin-left', '400px');
					break;
				case 'contact':
					menu.setStyle('margin-left', '500px');
					break;
			}
			if(a != null && menu != null)
			{
				curMenu.push(menu);
				menu.fx = new Fx.Slide(menu, {
					chain: 'ignore'
				});
				a.addEvent('mouseover', (function(){
					for(var j = 0; j < curMenu.length; j++)
					{
						if(curMenu[j] != this)
						{
							curMenu[j].fx.hide();
						}
					}
					this.fx.slideIn();
				}).bind(menu));

				/*
				var outEvent = function(evt){
					var rel = evt.relatedTarget;
					while(rel != null && rel != document.body)
					{
						if(rel == this[0] || rel == this[1])
						{
							return;
						}
						rel = rel.parentNode;
					}
					this[1].fx.slideOut();
				};

				spans[i].addEvent('mouseout', outEvent.bind([spans[i], menu]));
				menu.addEvent('mouseout', outEvent.bind([spans[i], menu]));
				

				menu.setStyle('visibility', 'visible');
				$(menu.parentNode).setStyle('position', 'absolute');
				//menu.setStyle('position', 'absolute');
				menu.fx.hide();
			}
		}
	}
	*/
});

var sclSize = 0;
var sclIndex = 0;
var sclFx;
var sclFxRunning = false;
var sclFxTimer;

window.addEvent('resize', function(){
	//调整轮播图div尺寸
	//alert('resize');
	if($('hotimg_scl'))
	{
		sclSize = $$('.hotimgs')[0].getSize().x;
		resizeScl();
	}
});

window.addEvent('scroll', function(){
	//alert('scroll');
	if(sclFxRunning)
	{
		clearTimeout(sclFxTimer);
		sclGo();
	}
});

function resizeScl()
{
	try
	{
		var scls = $$('.h_img');
		$('hotimg_wrapper').setStyle('width', (scls.length * sclSize) + 'px');
		scls.each(function(item){
			item.setStyle('width', sclSize + 'px');
		});
	}
	catch(ex)
	{
	}
}

function sclGo()
{
	var nextScl = (sclIndex + 1) * sclSize;
	sclFxRunning = true;
	sclFx.start(nextScl, 0);
	var ps2 = $$('.hotimgs_preview div.preview');

	ps2.each(function(p){
		p.removeClass('act');
		p.setStyle('opacity', 0.8);
	});

	ps2[(sclIndex + 1) % 7].addClass('act');
	ps2[(sclIndex + 1) % 7].setStyle('opacity', 1);
	sclFxTimer = sclGo.delay(8000);
}


function switchPanel(btn, panel, actClass)
{
	btn = $(btn);
	panel = $(panel);
	var bc = $(btn.parentNode);
	var btns = bc.getChildren(btn.tagName);
	for(var i = 0; i < btns.length; i++)
	{
		btns[i].removeClass(actClass);
	}
	btn.addClass(actClass);
	
	var pc = $(panel.parentNode);
	var panels = pc.getChildren(panel.tagName);
	for(var i = 0; i < panels.length; i++)
	{
		panels[i].setStyle('display', 'none');
	}
	panel.setStyle('display', '');
}

function showTopMenu(id)
{
	var div = $(id);

	var bros = $(div.parentNode).getChildren(div.tagName);

	bros.each(function(item){
		$(item).setStyle('display', 'none');
	});
	div.setStyle('display', '');
}