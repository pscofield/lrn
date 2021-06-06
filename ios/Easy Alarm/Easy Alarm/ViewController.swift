//
//  ViewController.swift
//  Easy Alarm
//
//  Created by Prateek Sharma on 4/25/20.
//  Copyright © 2020 Prateek Sharma. All rights reserved.
//

import UIKit
import EventKit
import AVFoundation

// TODO: refer to https://github.com/asketola/EKAlarmExample/blob/master/EKAlarmExample/ViewController.swift.
// https://www.google.com/search?q=ring+an+alarm+ios+swift
// https://stackoverflow.com/questions/50644978/how-are-some-alarm-apps-such-as-alarmy-able-to-play-a-sound-on-iphone-when-the-a
// Alarmy app notification: to ring alarm in silent mode, app should be in background. I had force closed the app.

// TODO support these times:
// in 12; at 12; every 3 days; @12; thursday morning; weekday nights; every other weekend; 2h dryer; 530 dryer; 1.5h dryer;

class ViewController: UIViewController {

    // Input field where the user enters the command.
    @IBOutlet weak var alarmTitleView: UITextField!
    // We show the status of the command here.
    @IBOutlet weak var statusLabel: UILabel!
    var audioPlayer: AVAudioPlayer!

    override func viewDidLoad() {
        super.viewDidLoad()
        // Load the keyboard text input as soon as the screen loads.
        alarmTitleView.becomeFirstResponder()
        do {
            try AVAudioSession.sharedInstance().setCategory(
                AVAudioSession.Category.playAndRecord,
                options: [AVAudioSession.CategoryOptions.duckOthers, AVAudioSession.CategoryOptions.defaultToSpeaker]
            )
            try AVAudioSession.sharedInstance().setActive(true)
            UIApplication.shared.beginReceivingRemoteControlEvents()
        } catch {
          Swift.print("Audio Session error: \(error)")
        }
        Swift.print("EXIT: viewDidLoad")
    }

    @IBAction func alarmTitleAction(_ sender: UITextField) {
        let providedInput = alarmTitleView.text ?? "Cook 30s"
        alarmTitleView.text = ""
        let alarmTitle = getAlarmTitle(userInput: providedInput)
        let alarmTime = maybeGetAbsoluteTime(userInput: providedInput)
        if (alarmTime != nil) {
            Swift.print("alarmTime != nil")
            Swift.print("alarmTime = \(printDate(date: alarmTime!))")
            doAllThingsNotif(alarmTitle: alarmTitle, alarmTime: alarmTime!, audioPlayer: &audioPlayer)
        } else {
            let alarmOffset = getAlarmRelativeTimeOffset(userInput: providedInput)
            statusLabel.text = "Will remind after \(alarmOffset) seconds."
            Swift.print("Value of alarmOffset=\(alarmOffset)")
            doAllThingsNotif(alarmTitle: alarmTitle, alarmOffset: Int(alarmOffset), audioPlayer: &audioPlayer)
        }
        // Close keyboard after user enters the command.
        // sender.resignFirstResponder()
        Swift.print("EXIT: alarmTitleAction")
    }

}

