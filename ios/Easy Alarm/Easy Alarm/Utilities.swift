//
//  Utilities.swift
//  Easy Alarm
//
//  Created by Prateek Sharma on 5/31/20.
//  Copyright © 2020 Prateek Sharma. All rights reserved.
//

import Foundation

public func printDate(date: Date) -> String {
    let formatter = DateFormatter()
    formatter.dateFormat = "yyyy-MM-dd HH:mm:ss"
    formatter.calendar = Calendar.current
    return formatter.string(from: date)
}
