The following things are added to the HTML:
  * HTML 5 doctype
  * Yahoo CSS reset file before all other stylesheets (loaded from Yahoo's CDN)
  * JQuery UI stylesheet (loaded from Google's CDN)
  * JQuery and JQueryUI javascript before the first script tag (or at the end of the body if none found)
  * A CSS class is added to the body tag that is the page's url path e.g. page-news\_recent
    * A prefix of "page-" is added
    * Slashes in the path are converted to underscores

If web.config is in debug mode the HTML is pretty printed, otherwise the white space is stripped.

Your HTML will look something like this:

```
<!DOCTYPE html>
<html>
  <head>
    <title>Minimal Website</title>
    <link href="http://yui.yahooapis.com/2.7.0/build/reset/reset-min.css" type="text/css" rel="stylesheet" />
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/themes/ui-lightness/jquery-ui.css" type="text/css" rel="stylesheet" />
    <link href="/_theme/minimal.css" type="text/css" rel="stylesheet" />
  </head>
  <body class="page-">
    <div class="header"></div>
    <ul id="cms-navigation">
      <li data-path="" class="level-0 current">
        <span>Home</span>
      </li>
    </ul>
    <div></div>
    <a id="cms-admin-link" href="#">Log In</a>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/jquery-ui.min.js"></script>
    <script type="text/javascript">/*<![CDATA[*/window.cms = { urlBase: "/" }//]]></script>
    <script type="text/javascript" src="/admin/OpenId/anonymous.js"></script>
  </body>
</html>
```

When logged in the HTML looks like this:
```
<!DOCTYPE html>
<html>
  <head>
    <title>Minimal Website</title>
    <link href="http://yui.yahooapis.com/2.7.0/build/reset/reset-min.css" type="text/css" rel="stylesheet" />
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/themes/ui-lightness/jquery-ui.css" type="text/css" rel="stylesheet" />
    <link href="/_theme/minimal.css" type="text/css" rel="stylesheet" />
    <link href="/admin/admin.css" type="text/css" rel="stylesheet" />
  </head>
  <body class="page-">
    <div class="header">
      <div class="global-editable" data-content-id="header">
        <span class="empty">Double-click here to enter some text.</span>
      </div>
    </div>
    <ul id="cms-navigation">
      <li data-path="" class="level-0 current">
        <span>Home</span>
      </li>
    </ul>
    <div>
      <div class="editable" data-content-id="">
        <span class="empty">Double-click here to enter some text.</span>
      </div>
    </div>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/jquery-ui.min.js"></script>
    <script type="text/javascript">/*<![CDATA[*/window.cms = { page: { path: "", title: "", name: "", description: "", template: "page.htm", navigation: true }, urlBase: "/", adminId: "http://andrewdavey.myopenid.com/", templates: ["Page.htm"], authType: "OpenId" }//]]></script>
    <script type="text/javascript" src="/admin/jquery.form-2.28.js"></script>
    <script type="text/javascript" src="/admin/jquery.jtree.1.0.js"></script>
    <script type="text/javascript" src="/admin/fckeditor/fckeditor.js"></script>
    <script type="text/javascript" src="/admin/admin.js"></script>
  </body>
</html>
```

Note the `<div class="editable" data-content-id="">` wraps around editable content.
Note the javascript object containing page information.
Note some of the extra javascript used for the admin experience.