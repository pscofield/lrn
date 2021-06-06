//
//  NotificationHandler.swift
//  Easy Alarm
//
//  Created by Prateek Sharma on 5/11/20.
//  Copyright © 2020 Prateek Sharma. All rights reserved.
//

import Foundation
import AVFoundation
import UserNotifications

public func doAllThingsNotif(alarmTitle: String, alarmOffset: Int, audioPlayer: inout AVAudioPlayer!) {
    if (alarmTitle.starts(with: "test")) {
        return;
    }
    requestAuthorization()
    scheduleNotification(alarmTitle: alarmTitle, alarmOffset: alarmOffset)
    scheduleSoundPlay(alarmOffset: alarmOffset, audioPlayer: &audioPlayer)
}

public func doAllThingsNotif(alarmTitle: String, alarmTime: Date, audioPlayer: inout AVAudioPlayer!) {
    if (alarmTitle.starts(with: "test")) {
        return;
    }
    requestAuthorization()
    scheduleNotification(alarmTitle: alarmTitle, alarmTime: alarmTime)
    scheduleSoundPlay(alarmOffset: Int(alarmTime.timeIntervalSince(Date())), audioPlayer: &audioPlayer)
}

private func requestAuthorization(completion: ((_ granted: Bool)->())? = nil) {
    let center = UNUserNotificationCenter.current()
    center.requestAuthorization(options: [.alert, .badge, .sound]) { (granted, error) in
        if granted {
            Swift.print("We have notifications permission")
        } else {
            Swift.print("NO notifications permissions.")
        }
    }
}

private func scheduleNotification(alarmTitle: String, alarmOffset: Int) {
    let alarmTime = Date(timeInterval: TimeInterval(alarmOffset), since: Date())
    scheduleNotification(alarmTitle: alarmTitle, alarmTime: alarmTime)
//    let center = UNUserNotificationCenter.current()
//    let content = UNMutableNotificationContent()
//    content.title = alarmTitle
//    content.body = "."
//    content.categoryIdentifier = "alarm"
//    content.userInfo = ["customData": "fizzbuzz"]
//    content.sound = UNNotificationSound.default
//    // for absolute times = UNCalendarNotificationTrigger
//    let trigger = UNTimeIntervalNotificationTrigger(timeInterval: TimeInterval(alarmOffset), repeats: false)
//    let request = UNNotificationRequest(identifier: UUID().uuidString, content: content, trigger: trigger)
//    center.add(request, withCompletionHandler:  { (_) in
//               Swift.print("EXIT: withCompletionHandler.")
//    })
//    Swift.print("Scheduled a notification for \"\(alarmTitle)\" after \(alarmOffset) seconds.")
}

private func scheduleNotification(alarmTitle: String, alarmTime: Date) {
    let center = UNUserNotificationCenter.current()
    let content = UNMutableNotificationContent()
    content.title = alarmTitle
    content.sound = UNNotificationSound.default
    let dateComponents = Calendar.current.dateComponents([.year,.month,.day,.hour,.minute,.second], from: alarmTime)
    let trigger = UNCalendarNotificationTrigger(dateMatching: dateComponents, repeats: false)
    let request = UNNotificationRequest(identifier: UUID().uuidString, content: content, trigger: trigger)
    center.add(request, withCompletionHandler:  { (_) in
               Swift.print("EXIT: withCompletionHandler.")
    })
    Swift.print("Scheduled a notification for \"\(alarmTitle)\" after \(alarmTime) seconds.")
}

private func scheduleSoundPlay(alarmOffset: Int, audioPlayer: inout AVAudioPlayer!) {
    do {
        audioPlayer = try AVAudioPlayer(
            contentsOf: URL(fileURLWithPath: Bundle.main.path(forResource: "alarmsound", ofType: "mp3")!)
        )
        audioPlayer.play(atTime: audioPlayer.deviceCurrentTime + Double(alarmOffset))
    } catch is Error {
        Swift.print("error when playing sound")
    }
    Swift.print("EXIT: scheduleSoundPlay.")
}
