  @Notes
  Feature: Note Management
  As a user
  I want to manage notes (create, update, delete, retrieve)
  So that I can store and organize my information effectively

  Background:
  Given I am logged into Evernote

  @CreateNote
  Scenario: Create a new note
    When I click on New Note button
    And I create a new note with the title 'Test Note' and description 'This is a test note'    
    And I sign out of my account
    And I log in into my Evernote account with the credentials
    |username              |password     |
    |pa.segoviam@gmail.com | Piojita.144 |
    And I open my note titled 'Test Note'
    Then the title of my note should be 'Test Note'
    And the description of my note should be 'This is a test note'
    