# gollum
Sample project with Web API 2
 
## :octocat: References

Dependency Injection | Unit Testing | Security | User Interface | Logging 
------------ | ------------- | -------------  | ------------- | -------------
Used [Ninject]() | Used [Moq](https://github.com/Moq/moq4/wiki/Quickstart) & [xUnit](https://xunit.github.io/) | :hourglass_flowing_sand: | :hourglass: | :negative_squared_cross_mark:




## :mailbox_with_mail: To Do

- [x] **Injection** with <del>Unity</del> :arrow_right_hook: Ninject
- [x] **Unit Testing** with <del>JustMock</del> :arrow_right_hook: Moq
- [ ] **Routing** /// :clubs: Conventional vs. :spades: Attribute Based (Semi-complete)
- [ ] **Claims Based Authentication** - Not implemented
- [ ] **User Interface** with Ng2 & TypeScript
- [ ] **Logger** - Not yet decided


#### Complete that one : 

```cs
	
    public static class HttpRequestMessageFactory
    {
        public static HttpRequestMessage CreateRequestMessage(HttpMethod method = null, string uriString = null)
        {
            method = method ?? HttpMethod.Get;
            var uri = string.IsNullOrWhiteSpace(uriString)
                ? new Uri("http://localhost:12345/api/whatever")
                : new Uri(uriString);
            var requestMessage = new HttpRequestMessage(method, uri);
            requestMessage.SetConfiguration(new HttpConfiguration());
            return requestMessage;
        }
    }
    
```



## :anchor: To Read 

* Integration Tests
   * :closed_lock_with_key: [Integration Testing](http://tostring.it/2012/07/23/an-easy-way-to-write-an-integration-test-with-web-api/)
   * :closed_lock_with_key: [In Memory Integration Testing](http://www.strathweb.com/2012/06/asp-net-web-api-integration-testing-with-in-memory-hosting/)


* Tests
	* About :lock: [IHttpActionResult / Web API 2](http://stackoverflow.com/questions/31485618/xunit-test-ihttpactionresult-web-api-2-function-for-custom-message)
	* About :unlock: [ Unit Testing](http://www.asp.net/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api)


* NuDoq
   * [Ninject Ref](http://www.nudoq.org/#!/Projects/Ninject)
   * [Moq Ref](http://www.nudoq.org/#!/Projects/Moq)





