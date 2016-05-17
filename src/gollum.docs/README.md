# Stuff

This part consists of gathered info. 
<br/>
:beer:


## Several Things To Consider

Glossary here. Nothing else. 

#### WEBKIT ![Black Cat](http://findicons.com/files/icons/409/witchery/128/cat.png)

WebKit is an open source web browser engine, a layout engine software component for rendering web pages in web browsers.
(..see engines available [*here*](https://en.wikipedia.org/wiki/List_of_ECMAScript_engines).)
WebKit is also the name of the MacOSX system framework version of the engine that's used by Safari, Dashboard, Mail and many other OS X applications. 
* Apple uses the Nitro JavaScript engine within Safari, alongside WebKit. (*Nitro, SquirrelFish and SquirrelFish Extreme == JavaScriptCore*)
* Chromium uses the WebKit rendering engine. BUT, Chrome does NOT use the Nitro Engine - has its own JavaScript engine called V8.
(*[**V8**](https://developers.google.com/v8/): open source JavaScript engine. Compiles JS to native machine code* (MIPS ISAs, x86-x64, ARM, IA-32) *before executing it.*)


#### Working with TypeScript

##### Configuration // Compiler Options for TypeScript
Compiler options can be specified using MSBuild properties within an MSBuild project.

Basic useful feature list:
```xml
<PropertyGroup>
	<TypeScriptToolsVersion>1.8</TypeScriptToolsVersion>
    <TypeScriptTarget>ES5</TypeScriptTarget>
    <TypeScriptJSXEmit>None</TypeScriptJSXEmit>
    <TypeScriptCompileOnSaveEnabled>True</TypeScriptCompileOnSaveEnabled>
    <TypeScriptNoImplicitAny>False</TypeScriptNoImplicitAny>
    <TypeScriptModuleKind>CommonJS</TypeScriptModuleKind>
    <TypeScriptRemoveComments>False</TypeScriptRemoveComments>
    <TypeScriptOutFile />
    <TypeScriptOutDir />
    <TypeScriptGeneratesDeclarations>False</TypeScriptGeneratesDeclarations>
    <TypeScriptNoEmitOnError>True</TypeScriptNoEmitOnError>
    <TypeScriptSourceMap>True</TypeScriptSourceMap>
    <TypeScriptMapRoot />
    <TypeScriptSourceRoot />
    <TypeScriptExperimentalDecorators>True</TypeScriptExperimentalDecorators>
    <TypeScriptEmitDecoratorMetadata>True</TypeScriptEmitDecoratorMetadata>
  </PropertyGroup>

