In your web.config the follow appSettings can be used:
```
<appSettings>
  <add key="auth-type" value="SimplePassword" />
  <add key="password" value="test" /> <!-- Only used when auth-type is SimplePassword -->
  <add key="theme" value="plain" />
</appSettings>
```

auth-type can be "OpenId" or "SimplePassword". This controls the type of authentication used.

You can also control the various external resources used by Pronto.

| **appSetting key** | **default value** |
|:-------------------|:------------------|
| reset-css          | http://yui.yahooapis.com/2.7.0/build/reset/reset-min.css |
| jquery-js          | http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js |
| jquery-ui-js       | http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/jquery-ui.min.js |
| jquery-ui-css      | http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/themes/ui-lightness/jquery-ui.css |