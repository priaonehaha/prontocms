Each page in Pronto needs to have an associated template.
Templates are HTML files with the addition of plugin calls, which are XML processing instructions. See BuiltInPlugins for more information.

```
<html>
<head>
    <title><?title?></title>
    <?theme layout.css?>
    <?theme formatting.css?>
</head>
<body>
    <div id="content" class="container">
        <div class="containee">
            <?content?>
        </div>
    </div>
    
    <div id="navigation" class="container">
        <div class="containee">
            <?navigation?>
        </div>
    </div>
    
    <div id="header" class="container">
        <div class="containee">
            <?globalcontent header?>
        </div>
    </div>
        
    <div id="footer" class="container">
        <div class="containee">
            <?globalcontent footer?>
        </div>
    </div>
    
    <div id="admin" class="container">
        <div class="containee">
            <?admin?>
        </div>
    </div>
</body>
</html>
```

The template is read by an XML parser, so you will need to close tags correctly and quote all attribute values. The view engine will add the HTML 5 doctype for you.