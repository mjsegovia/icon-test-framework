  @Login
  Feature: Evernote Login Tests
   In order to be able to create notes
   as a registered user
   I want to login to the website

   Background:
    Given I am on the Evernote login page 

   @HappyPath
   Scenario: Successful login to Evernote    
    When I enter a valid email 'pa.segoviam@gmail.com'
    And I enter a valid password 'Piojita.144'    
    Then I should be logged in successfully
    And I should see the user dashboard

   @NegativeTest
   Scenario: Unsuccessful login to Evernote with incorrect email    
    When I enter an invalid email 'invaliduser@example.com'
    And I click on the continue button
    And I enter a valid password 'Piojita.144'
    And I click on the continue button
    Then I should see an error message 'Check your credentials. We couldn’t match your email, username, or password.'

   @NegativeTest
   Scenario: Unsuccessful login to Evernote with incorrect password
    When I enter a valid email 'validuser@example.com'
    And I click on the continue button
    And I enter an invalid password 'invalidPassword123'
    And I click on the continue button
    Then I should see an error message 'Check your credentials. We couldn’t match your email, username, or password.'

  