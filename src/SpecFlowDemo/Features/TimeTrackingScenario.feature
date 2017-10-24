@Login
Feature: FillTimetracking
	In order to fill time tracking for lazy people


Scenario Outline: FillTimeTracking
Given I Open Timetracking Page 'http://ihome/sites/PO/Deloitte/StudioK/Lists/StudioK%20Time%20Tracking'
And I Fill Time Tracking Form
   | Activity     | TimeSpent     | Category     | SubProject     | RecordType     | Billable     |
   | <Activity_e> | <TimeSpent_e> | <Category_e> | <SubProject_e> | <RecordType_e> | <Billable_e> |
 #And I choose switch OFF bilable if '<Bilable_e>'

 Examples:
| Activity_e | TimeSpent_e | Category_e  | SubProject_e  | RecordType_e       | Billable_e |
| *          | 8,0         | 2 - Testing |20 USI Space Management| 1.1 - Work regular | true       |         
#| PTO		  | 0,0         | 2 - Testing | 40 Magnet O&M | 2.6 - Absence	   | false      |

#	Category *
#1 - Development
#2 - Testing

#	SubProject *
#10 WS Hoteling
#20 Magnet Brand Refresh
#30 VC Planner
#40 Magnet O&M

#	Record type *
#1.1 - Work regular
#1.2 - Work overtime
#1.3 - Work on holidays
#1.4 - Work for day-off
#1.5 - Work night overtime
#1.6 - OCD Weekday
#1.7 - OCD Weekend
#2.3 - Illness
#2.4 - Day-off worked off
#2.5 – Day-off internally compensated
#2.6 - Absence
#3.1 - Work on site
#3.2 - Travel
#3.3 - Travel on holiday
#3.4 – Holiday on site
#3.5 – Work on site on holiday
#4.1 - Direct order
