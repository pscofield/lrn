//
//  CommandParser.swift
//  Easy Alarm
//
//  Created by Prateek Sharma on 5/26/20.
//  Copyright © 2020 Prateek Sharma. All rights reserved.
//

import Foundation

public func getAlarmTitle(userInput: String!) -> String {
    let regex = try! NSRegularExpression(pattern: #"(.*)\ [\d\@]\d?.*"#, options: .caseInsensitive)
    let result = regex.matches(in:userInput, range:NSMakeRange(0, userInput.utf16.count))
    let targetRange = Range(result[0].range(at: 1), in: userInput)
    return String(userInput[targetRange!])
}
