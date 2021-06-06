import os
from sklearn.linear_model import LogisticRegression
from sklearn import preprocessing
from sklearn.model_selection import train_test_split
import sklearn.metrics as metrics
import numpy as np
import pandas as pd

DATA_FOLDER = "/Users/ips/Documents/ml/kaggle/titanic/data/"
OUTPUT_FILE_NAME = "submission2.csv"


def preprocess_data(raw_data, is_test=False):
    all_columns = ["Pclass", "Sex", "Age", "SibSp", "Parch", "Fare", "Cabin", "Embarked", "Survived"]
    feature_columns = all_columns.copy()
    feature_columns.remove("Survived")
    data = raw_data[feature_columns if is_test else all_columns].copy()
    data.replace([np.nan], 0, inplace=True)
    one_hot_encoding(data)
    data[feature_columns] = preprocessing.scale(data[feature_columns])
    return data


def one_hot_encoding(data):
    data["Sex"] = data["Sex"].apply(lambda x: 0 if x == "male" else 1)
    data["Embarked"] = data["Embarked"].apply(lambda x: 0 if x == "C" else (1 if x == "Q" else 2))
    data["Cabin"] = data["Cabin"].apply(lambda x: str(x)[0])
    encoder = preprocessing.LabelEncoder()
    encoder.fit(data["Cabin"].values)
    data["Cabin"] = encoder.transform(data["Cabin"].values)


# Train.
train_data_raw = pd.read_csv(DATA_FOLDER + 'train.csv')
train_data = preprocess_data(train_data_raw)
x_train = train_data.drop(columns=["Survived"])
y_train = train_data[["Survived"]].to_numpy().flatten()
model = LogisticRegression()
model.fit(x_train, y_train)

# Test.
test_data_raw = pd.read_csv(DATA_FOLDER + 'test.csv')
test_data = preprocess_data(test_data_raw, is_test=True)
y_test = model.predict(test_data)
y_test = y_test.reshape(y_test.size, 1)

# Output.
passenger_id = test_data_raw[["PassengerId"]]
y_test_df = pd.DataFrame(data=y_test, columns=["Survived"])
final_submission_data = pd.concat(
    [passenger_id.reset_index(drop=True), y_test_df.reset_index(drop=True)],
    axis=1)
final_submission_data.to_csv(DATA_FOLDER + OUTPUT_FILE_NAME, index=False)
