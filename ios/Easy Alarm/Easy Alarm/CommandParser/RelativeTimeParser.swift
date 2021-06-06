//
//  RelativeTimeParser.swift
//  Easy Alarm
//
//  Created by Prateek Sharma on 5/31/20.
//  Copyright © 2020 Prateek Sharma. All rights reserved.
//

import Foundation

private func getAlarmRelativeTimeUnit(userInput: String!) -> String {
    let regex = try! NSRegularExpression(pattern: #"\d+\ ?(s|m|h|d)"#, options: .caseInsensitive)
    let result = regex.matches(in:userInput, range:NSMakeRange(0, userInput.utf16.count))
    let targetRange = Range(result[0].range(at: 1), in: userInput)
    return String(userInput[targetRange!])
}

private func getAlarmRelativeTimeValue(userInput: String!) -> Int {
    let regex = try! NSRegularExpression(pattern: #"(\d+)\ ?(s|m|h|d)"#, options: .caseInsensitive)
    let result = regex.matches(in:userInput, range:NSMakeRange(0, userInput.utf16.count))
    let targetRange = Range(result[0].range(at: 1), in: userInput)
    return Int(String(userInput[targetRange!]))!
}

public func getAlarmRelativeTimeOffset(userInput: String!) -> Int {
    let timeMagnitude = getAlarmRelativeTimeValue(userInput: userInput)
    let timeUnit = getAlarmRelativeTimeUnit(userInput: userInput)
    if (timeUnit == "s") {
        return timeMagnitude
    } else if (timeUnit == "m") {
        return timeMagnitude * 60
    } else if (timeUnit == "h") {
        return timeMagnitude * 3600
    } else if (timeUnit == "d") {
        return timeMagnitude * 86400
    } else {
        Swift.print("error when getting relative time")
        return -1
    }
}
