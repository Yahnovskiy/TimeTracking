@Login
Feature: FillTimetracking
	In order to access to my Github account
	As a user with existing account
	I want to be able to sign in to GitHub 


Scenario Outline: FillTimeTracking
Given I Open Timetracking Page 'http://ihome/sites/PO/Deloitte/StudioK/Lists/StudioK%20Time%20Tracking'

And I Fill Time Tracking Form
   | Activity     | TimeSpent     | Category     | SubProject     | RecordType     | BilableOFF     |
   | <Activity_e> | <TimeSpent_e> | <Category_e> | <SubProject_e> | <RecordType_e> | <Bilable_e> |
 And I choose switch OFF bilable if '<Bilable_e>'

 Examples:
| Activity_e | TimeSpent_e | Category_e  | SubProject_e  | RecordType_e       | BilableOFF_e |
| *          | 8,0         | 2 - Testing | 40 Magnet O&M | 1.1 - Work regular | true     |            
#|For PTO          | 9,0         | 2 - Testing | 40 Magnet O&M | 1.1 - Work regular | false     |