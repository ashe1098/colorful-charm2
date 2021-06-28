# ふぉるこせるまぁ～れ！！

3Daysゲームジャム「[ColorfulCharm2](https://peatix.com/event/1889715)」で制作した火事消火型スコアアタックゲームです。

<img src="https://raw.githubusercontent.com/ashe1098/colorful-charm2/main/images/title.png" width=70%>

## プレイ

https://ashe1098.github.io/colorful-charm2/

Sランク目指してファイト！！！

## 実装の担当
5人チーム（プランナー1・デザイナー2・エンジニア2）のうち、エンジニアとしてフロントサイドの開発を担当しました。  
キャラクターの挙動やパラメータの管理など、ゲームギミックに関する全般を実装しました。具体的な内容を以下に列挙します。

- キャラクターの操作（移動・放水・給水）
- キャラクターのパラメータ管理（水の消費・回復）
- 建物の状態遷移（発火・鎮火・全焼）
- スコアやタイムの管理（消火によるボーナス・全焼によるペナルティ）
- アニメーションの挙動管理（移動・放水・給水）
- 効果音の管理（移動・放水・給水）

実装したスクリプトの参照先は以下の通りです。

- [GameMaster.cs](https://github.com/ashe1098/colorful-charm2/blob/main/Scripts/ManagerScript/GameMaster.cs)
- [その他のスクリプト郡](/Scripts/GamePlay)
