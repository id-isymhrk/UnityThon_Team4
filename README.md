# UnityThon_Team4
## 簡単な流れ
1. [Issues]→[new issue] で新しくissueを作成する
1. [Feature]と[Bug]の項目があるのでそのテンプレートを活用してください
1. 作業に移る時は新しくブランチを作成します
1. 作業はそのブランチ内で行いましょう
1. 作業が終わったら`git push origin~`の一連の流れを行ってください
1. githubのページ（本ページ）の[PullRequest]のタブに新しく緑色で[Compare&PullRequest]とあると思うのでそれをクリック
1. プルリクエストの詳細を書いて他の人に確認してからメインブランチにくっつけましょう
1. 作業が終わったら、また一番上から始めます


## ブランチの作り方
`git checkout -b feature/#issue番号/わかる名前` または `git branch feature/#issue番号/わかる名前`

※issueを作った時にできる"#01"のような番号を「issue番号」と呼称しています。

ブランチは作業ごとに新しく作成してもらえると助かります

## pushの時の注意点
`git push origin 自分のいるブランチの名前` 

↑mainにpushしないように注意してください