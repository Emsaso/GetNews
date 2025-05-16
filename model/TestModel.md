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

## How to test the methods
```mermaid
stateDiagram-v2
[*] --> TestClass: 
    Notes: Initializing a testClass with setup
        TestClass --> Setup: Declear properties
        Setup --> TestMethod: Assigning values to Properties 
    TestMethod --> AssertionState: Arrange / Act / Assert (AAA)

    AssertionState --> True:Expected output
    AssertionState --> False:Not expected output
        True --> [*]:Test OK
        False --> TestMethod:Debugg error and test again
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
        

        AssertionState --> True:Expected output
        AssertionState --> False:Not expected output
        
        True --> [*]:Test OK
        False --> SigUpWithSubscription:Debugg error and test again


```

##  TestSignUpInvalidEmailAdress
```mermaid
stateDiagram-v2
    [*] --> SignUpInvalidEmailAdress
        SignUpInvalidEmailAdress --> AssertionState
        
        AssertionState --> True:Expected output
        AssertionState --> False:Not expected output
        
        True --> [*]:Test OK
        False --> SigUpInvalidEmailAddress:Debugg error and test again


```

##  TestSignUpAlreadySubscribed
```mermaid
stateDiagram-v2
    [*] --> SignUpAlreadySubscribed
        SignUpAlreadySubscribed --> AssertionState
        
        AssertionState --> True:Expected output
        AssertionState --> False:Not expected output
        
        True --> [*]:Test OK
        False --> SigUpWAlreadySubscribed:Debugg error and test again

```

##  TestSignUpUnsubscribed
```mermaid
stateDiagram-v2
    [*] --> SignUpUnsubscribed
        SignUpUnsubscribed --> AssertionState
        
        AssertionState --> True:Expected output
        AssertionState --> False:Not expected output
        
        True --> [*]:Test OK
        False --> SigUpUnsubscribed:Debugg error and test again

```

##  TestSignUpWithExistingUnverified
```mermaid
stateDiagram-v2
    [*] --> SignUpWithExistingUnverified
        SignUpWithExistingUnverified --> AssertionState
        
        AssertionState --> True:Expected output
        AssertionState --> False:Not expected output
        
        True --> [*]:Test OK
        False --> SignUpWithExistingUnverified:Debugg error and test again

```

##  TestConfirm
```mermaid
stateDiagram-v2
    [*] --> Confirm
        Confirm --> AssertionState
        
        AssertionState --> True:Expected output
        AssertionState --> False:Not expected output
        
        True --> [*]:Test OK
        False --> Confirm:Debugg error and test again
```

##  TestInvalidConfirm
```mermaid
stateDiagram-v2
    [*] --> InvalidConfirm
        InvalidConfirm --> AssertionState
        
        AssertionState --> True:Expected output
        AssertionState --> False:Not expected output
        
        True --> [*]:Test OK
        False --> InvalidConfirm:Debugg error and test again
```

##  TestUnsubscribed
```mermaid
stateDiagram-v2
    [*] --> Unsubscribed
        Unsubscribed --> AssertionState
        
        AssertionState --> True:Expected output
        AssertionState --> False:Not expected output
        
        True --> [*]:Test OK
        False --> Unsubscribed:Debugg error and test again
```

##  TestUnsubscribedWithError
```mermaid
stateDiagram-v2
    [*] --> UnsubscribedWithError
        UnsubscribedWithError --> AssertionState
        
        AssertionState --> True:Expected output
        AssertionState --> False:Not expected output
        
        True --> [*]:Test OK
        False --> UnsubscribedWithError:Debugg error and test again
```