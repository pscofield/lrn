//
//  AbsoluteTimeParser.swift
//  Easy Alarm
//
//  Created by Prateek Sharma on 5/31/20.
//  Copyright © 2020 Prateek Sharma. All rights reserved.
//

import Foundation

public func maybeGetAbsoluteTime(userInput: String!) -> Date? {
    let regex = try! NSRegularExpression(pattern: #"\@(\d{2})([:\-.\ ])?(\d{2})\ ?(am|pm)"#, options: .caseInsensitive)
    let match = regex.matches(in:userInput, range:NSMakeRange(0, userInput.utf16.count))
    if (match.count == 0) {
        return nil
    }
    let hourValue = Int(String(userInput[Range(match[0].range(at: 1), in: userInput)!]))
    let minuteValue = Int(String(userInput[Range(match[0].range(at: 3), in: userInput)!]))
    let ampmValue = String(userInput[Range(match[0].range(at: 4), in: userInput)!])
    return getNextOccurringTime(
        hourValue: (hourValue! + ( (ampmValue == "pm") ? 12 : 0 )),
        minuteValue: minuteValue!
    )
}

private func getNextOccurringTime(hourValue: Int, minuteValue: Int) -> Date {
    let currentTime = Calendar.current.dateComponents([.year,.month,.day,.hour,.minute,.second], from: Date())
    var proposedAlarmTime = DateComponents(
        calendar: Calendar.current,
        year: currentTime.year,
        month: currentTime.month,
        day: currentTime.day,
        hour: hourValue,
        minute: minuteValue
    )
    if (Calendar.current.date(from: currentTime)! < Calendar.current.date(from: proposedAlarmTime)!) {
        return Calendar.current.date(from: proposedAlarmTime)!
    } else {
        proposedAlarmTime.day = proposedAlarmTime.day! + 1
        return Calendar.current.date(from: proposedAlarmTime)!
    }
}
