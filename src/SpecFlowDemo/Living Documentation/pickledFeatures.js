jsonPWrapper ({
  "Features": [
    {
      "RelativeFolder": "Login success.feature",
      "Feature": {
        "Name": "FillTimetracking",
        "Description": "In order to access to my Github account\r\nAs a user with existing account\r\nI want to be able to sign in to GitHub ",
        "FeatureElements": [
          {
            "Examples": [
              {
                "Name": "",
                "TableArgument": {
                  "HeaderRow": [
                    "Activity_e",
                    "TimeSpent_e",
                    "Category_e",
                    "SubProject_e",
                    "RecordType_e",
                    "Bilable_e"
                  ],
                  "DataRows": [
                    [
                      "*",
                      "8,0",
                      "2 - Testing",
                      "40 Magnet O&M",
                      "1.1 - Work regular",
                      "true"
                    ]
                  ]
                },
                "Tags": [],
                "NativeKeyword": "Examples"
              }
            ],
            "Name": "FillTimeTracking",
            "Slug": "filltimetracking",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "I Open Timetracking Page 'http://ihome/sites/PO/Deloitte/StudioK/Lists/StudioK%20Time%20Tracking'",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I Fill Time Tracking Form",
                "TableArgument": {
                  "HeaderRow": [
                    "Activity",
                    "TimeSpent",
                    "Category",
                    "SubProject",
                    "RecordType",
                    "Bilable"
                  ],
                  "DataRows": [
                    [
                      "<Activity_e>",
                      "<TimeSpent_e>",
                      "<Category_e>",
                      "<SubProject_e>",
                      "<RecordType_e>",
                      "<Bilable_e>"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": [
                  {
                    "Text": "#|*          | 9,0         | 2 - Testing | 40 Magnet O&M | 1.1 - Work regular | false     |"
                  }
                ]
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          }
        ],
        "Result": {
          "WasExecuted": false,
          "WasSuccessful": false
        },
        "Tags": [
          "@Login"
        ]
      },
      "Result": {
        "WasExecuted": false,
        "WasSuccessful": false
      }
    }
  ],
  "Summary": {
    "Tags": [
      {
        "Tag": "@Login",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      }
    ],
    "Folders": [
      {
        "Folder": "Login success.feature",
        "Total": 1,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 1
      }
    ],
    "NotTestedFolders": [
      {
        "Folder": "Login success.feature",
        "Total": 0,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 0
      }
    ],
    "Scenarios": {
      "Total": 1,
      "Passing": 0,
      "Failing": 0,
      "Inconclusive": 1
    },
    "Features": {
      "Total": 1,
      "Passing": 0,
      "Failing": 0,
      "Inconclusive": 1
    }
  },
  "Configuration": {
    "GeneratedOn": "22 серпня 2017 17:19:03"
  }
});