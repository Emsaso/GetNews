# Visualisering av [SubscriptionServiceTest.cs](../../GetNews.Core.Test/SubscriptionServiceTest.cs)


##  How the Class is built
```mermaid
---
title: SubscriptionServiceTest | EmailTest
---
classDiagram
    Base <|--|>  EmailTest
    Base <|--|> SubscriptionServiceTest

    note "How the class is built up"
    
    namespace GetNewsCoreTest{

        class Base {
            EmailAddress UserEmail
            EmailAddress FakeEmail
            EmailAddress FakeEmail_1
        
            public void Setup()
            }

        class SubscriptionServiceTest {
            %%EmailAddress UserEmail
            %%EmailAddress FakeEmail
            %%EmailAddress FakeEmail_1
        
            %%public void Setup()
            public void TestNewSignUp()
            public void TestUnsubscribed()
            public void TestConfirmation()
            public void TestAlreadySubscribed()
            public void TestSignUpUnsubscribed()
            public void TestInvalidConfirmation()
            public void TestUnsubscribedWithError()
            public void SignUpInvalidEmailAddress()
            public void TestSignUpWithSubscription()
            public void TestSignUpWithExistingUnverified()  
        }

        class EmailTest{
            %%EmailAddress UserEmail
            %%EmailAddress FakeEmail
            %%EmailAddress FakeEmail_1
        
            %%public void Setup()
            public void TestCreateUnsubscribeEmail()
            public void TestCreateConfirmationEmail()
        }
    }
```

```mermaid
stateDiagram-v2
    
    [*] --> TestClass: 
    Notes: Initializing a testClass with setup
        TestClass --> Setup: Declear properties
        Setup --> TestMethod: Assigning values to Properties 
    TestMethod --> [*]: Arrange / Act / Assert (AAA)


```


##  TestNewSignUp
```mermaid
stateDiagram-v2
[*] --> TestNewSignUp:Collecting TestCase
    TestNewSignUp --> SubscriptionService.SignUp(emailAddress,null): Collecting Inputs
    
#    state AssertionState <<choice>>
#    state SubscriptionCheck <<choice>>
#    state EnsureEmailValidity <<choice>>

#    EnsureEmailValidity
#       [*] --> EnsureEmailValidity
#
#        state CollectingInputs
#        state HandleInvalidEmail
#        state join_state <<join>>

#        CollectingInputs --> EmailAddress.IsValid()
#            EmailAddress.IsValid()--> (bool)HandleInvalidEmail
#            HandleInvalidEmail  --> AssertionState

#        EmailAddress.IsValid() --> SubscriptionCheck
            
#            state HandleNullSubscription
#            HandleNullSubscription --> CreateSubScription
#            CreateSubScription --> AssertionState
        

    SubscriptionService.SignUp(emailAddress,null) --> AssertionState:CollectingOutputs
    
    AssertionState --> True:Expected output
    AssertionState --> False:Not expected output
    True --> [*]:Test OK
    False --> TestNewSignUp:Debugg error and test again
```
##  TestSignUpWithSubscription
```mermaid
stateDiagram-v2
    [*] --> SigUpWithSubscription
        SigUpWithSubscription --> AssertionState
        
        AssertionState --> True
        AssertionState --> False
        True --> [*]
        False --> [*]


```

##  TestSignUpInvalidEmailAdress
```mermaid
stateDiagram-v2
    [*] --> SignUpInvalidEmailAdress
        SignUpInvalidEmailAdress --> AssertionState
        
        AssertionState --> True
        AssertionState --> False
        True --> [*]
        False --> [*]


```

##  TestSignUpAlreadySubscribed
```mermaid
stateDiagram-v2
    [*] --> SignUpAlreadySubscribed
        SignUpAlreadySubscribed --> AssertionState
        
        AssertionState --> True
        AssertionState --> False
        True --> [*]
        False

```

##  TestSignUpWUnsubscribed
```mermaid
stateDiagram-v2
    [*] --> SignUpAlreadySubscribed
        SignUpAlreadySubscribed --> AssertionState
        
        AssertionState --> True
        AssertionState --> False
        True --> [*]
        False

```

##  TestSignUpWithExistingUnverified
```mermaid
stateDiagram-v2
    [*] --> SignUpInvalidEmailAdress
        SignUpInvalidEmailAdress --> AssertionState
        
        AssertionState --> True
        AssertionState --> False
        True --> [*]
        False

```

##  TestConfirm
```mermaid
stateDiagram-v2
    [*] --> SignUpInvalidEmailAdress
        SignUpInvalidEmailAdress --> AssertionState
        
        AssertionState --> True
        AssertionState --> False
        True --> [*]
        False
```

##  TestInvalidConfirm
```mermaid
stateDiagram-v2
    [*] --> SignUpInvalidEmailAdress
        SignUpInvalidEmailAdress --> AssertionState
        
        AssertionState --> True
        AssertionState --> False
        True --> [*]
        False
```

##  TestUnsubscribed
```mermaid
stateDiagram-v2
    [*] --> SignUpInvalidEmailAdress
        SignUpInvalidEmailAdress --> AssertionState
        
        AssertionState --> True
        AssertionState --> False
        True --> [*]
        False
```

##  TestUnsubscribedWithError
```mermaid
stateDiagram-v2
    [*] --> SignUpInvalidEmailAdress
        SignUpInvalidEmailAdress --> AssertionState
        
        AssertionState --> True
        AssertionState --> False
        True --> [*]
        False
```