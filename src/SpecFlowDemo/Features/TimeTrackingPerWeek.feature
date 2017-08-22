@Login
Feature: FillTimetracking
	In order to access to my Github account
	As a user with existing account
	I want to be able to sign in to GitHub 


Scenario Outline: FillTimeTracking
Given I Open Timetracking Page 'http://ihome/sites/PO/Deloitte/StudioK/Lists/StudioK%20Time%20Tracking'

And I Fill Time Tracking Form
   | Activity     | TimeSpent     | Category     | SubProject     | RecordType     | Bilable     |
   | <Activity_e> | <TimeSpent_e> | <Category_e> | <SubProject_e> | <RecordType_e> | <Bilable_e> |
 
 Examples:
| Activity_e | TimeSpent_e | Category_e  | SubProject_e  | RecordType_e       | Bilable_e |
| *          | 8,0         | 2 - Testing | 40 Magnet O&M | 1.1 - Work regular | true      |            
#|*          | 9,0         | 2 - Testing | 40 Magnet O&M | 1.1 - Work regular | false     |