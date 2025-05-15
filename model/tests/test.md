Visualisering av [SubscriptionServiceTest.cs](../../GetNews.Core.Test/SubscriptionServiceTest.cs)


##  How the Class is built
```mermaid
---
title: SubscriptionServiceTest
---
classDiagram
    note "How the class is built up"
    class SubscriptionServiceTest
        SubscriptionServiceTest: EmailAddress UserEmail
        SubscriptionServiceTest: EmailAddress FakeEmail
        SubscriptionServiceTest: EmailAddress FakeEmail_1
        SubscriptionServiceTest: public void Setup()
        SubscriptionServiceTest: public void TestNewSignUp()
        SubscriptionServiceTest: public void TestSignUpWithSubscription()
        SubscriptionServiceTest: public void SignUpInvalidEmailAddress()
        SubscriptionServiceTest: public void TestAlreadySubscribed()
        SubscriptionServiceTest: public void TestSignUpUnsubscribed()
        SubscriptionServiceTest: public void TestSignUpWithExistingUnverified()
        SubscriptionServiceTest: public void TestConfirmation()
        SubscriptionServiceTest: public void TestInvalidConfirmation()
        SubscriptionServiceTest: public void TestUnsubscribed()
        SubscriptionServiceTest: public void TestUnsubscribedWithError()

        SubscriptionServiceTest: public void TestCreateConfirmationEmail()
        SubscriptionServiceTest: public void TestCreateUnsubscribeEmail()
```
****
##  TestNewSignUp
```mermaid
stateDiagram-v2
[*] --> SubScriptionServiceTest
    SubscriptionServiceTest --> Setup: Initializing the Class variables
    Setup --> SubscriptionService.SignUp(emailAddress, null) : Calling function
    
    state AssertionState <<choice>>
    state SubscriptionCheck <<choice>>
    state EnsureEmailValidity <<choice>>

    EnsureEmailValidity
        [*] --> EnsureEmailValidity

        state CollectingInputs
        state HandleInvalidEmail
        state join_state <<join>>

        
        CollectingInputs --> EmailAddress.IsValid()
            EmailAddress.IsValid()--> (bool)HandleInvalidEmail
            HandleInvalidEmail  --> AssertionState

        
        EmailAddress.IsValid() --> SubscriptionCheck
            
            state HandleNullSubscription

            HandleNullSubscription --> AssertionState
        

    #SubscriptionService.SignUp(emailAddress, null) --> Assertion Test : Finished calling #the function ensures that the test returns true
    
    AssertionState --> True
    AssertionState --> False
    True --> [*]
    False --> [*]
```
##  TestSignUpWithSubscription
```mermaid
[*] --> SubScriptionServiceTest.cs
    
    AssertionState --> True
    AssertionState --> False
    True --> [*]
    False --> [*]

```

##  TestSignUpInvalidEmailAdress
```mermaid
[*] --> SubScriptionServiceTest.cs
****
    AssertionState --> True
    AssertionState --> False
    True --> [*]
    False --> [*]

```

##  TestSignUpAlreadySubscribed
```mermaid
[*] --> SubScriptionServiceTest.cs

    AssertionState --> True
    AssertionState --> False
    True --> [*]
    False --> [*]

```

##  TestSignUpWUnsubscribed
```mermaid

[*] --> SubScriptionServiceTest.cs

    AssertionState --> True
    AssertionState --> False
    True --> [*]
    False --> [*]

```

##  TestSignUpWithExistingUnverified
```mermaid
[*] --> SubScriptionServiceTest.cs

    AssertionState --> True
    AssertionState --> False
    True --> [*]
    False --> [*]

```

##  TestConfirm
```mermaid
[*] --> SubScriptionServiceTest.cs

    AssertionState --> True
    AssertionState --> False
    True --> [*]
    False --> [*]
```

##  TestInvalidConfirm
```mermaid
[*] --> SubScriptionServiceTest.cs

    AssertionState --> True
    AssertionState --> False
    True --> [*]
    False --> [*]
```

##  TestUnsubscribed
```mermaid
[*] --> SubScriptionServiceTest.cs

    AssertionState --> True
    AssertionState --> False
    True --> [*]
    False --> [*]
```

##  TestUnsubscribedWithError
```mermaid
[*] --> SubScriptionServiceTest.cs

    AssertionState --> True
    AssertionState --> False
    True --> [*]
    False --> [*]
```