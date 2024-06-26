# 비팔로

### 2D TOP_DOWN 생존 RPG 게임
---


## 목차
+ [프로젝트 소개](https://github.com/kimihea/AdvancedWeekProject?tab=readme-ov-file#프로젝트-소개)
+ [사용기술 스택](https://github.com/kimihea/AdvancedWeekProject?tab=readme-ov-file#사용기술-스택)
+ [트러블 슈팅](https://github.com/kimihea/AdvancedWeekProject?tab=readme-ov-file#trobule-shooting)
+ [만든 사람들](https://github.com/kimihea/AdvancedWeekProject?tab=readme-ov-file#만든-사람들)
---
### 👨‍🏫 프로젝트 소개
🔴[YOUTUBE](https://www.youtube.com/watch?v=2xg_Z5UV2tU)

:file_folder: [TeamNotion](https://teamsparta.notion.site/81d8c98db0374f2182268fdf725a2637)

**던전에 도전해서 더 강력해지세요**

**던전에서 몬스터를 사냥하고 얻은 전리품으로 강해지는 게임**

**💤피로도 관리는 필수**



### 사용기술 스택
1. ObjectPool - 미리 만들어둔 오브젝트를 재사용함으로써, 객체의 생성과 파괴에 쓰이는 메모리를 아낄 수 있다. 

2. ScritableObject - 정보를 클래스로 감싸서  저장과 사용을 간편하게 해준다.

3. 옵저버 패턴 - 플레이어의 입력을 자동으로 감지하여 객체에게 전달해줌, 객체 간의 결합도가 낮아 독립적으로 동작할 수 있다.

4. 싱글톤 패턴 - 게임 관리를 담당하는 Manager들을 싱글톤으로 생성,  동일한 객체를 사용해 메모리를 아끼고 접근이 용이하다.




### 💢Trobule Shooting💢
+ 게임의 일시정지 기능을 만들다가 생긴 문제

일시정지를 하면은 플레이어의 행동을 멈추게 하려고 Action을 실행 하지 못하게 했는데.

```csharp
public bool pause = false;

public void CallMoveEvent(Vector2 direction)
{
		if(pause) return;
    OnMoveEvent?.Invoke(direction);
}

public void CallLookEvent(Vector2 direction)
{
		if(pause) return;
    OnLookEvent?.Invoke(direction);
}

public void CallAttackEvent(AttackSO attackSO)
{
    if(pause) return;
    OnAttackEvent?.Invoke(attackSO);
}
```

![내 프로젝트2.gif](https://prod-files-secure.s3.us-west-2.amazonaws.com/83c75a39-3aba-4ba4-a792-7aefe4b07895/451e11c8-dddf-4105-b8f5-70adacdc2c59/%EB%82%B4_%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B82.gif)

중지해도 마지막으로 입력한 값을 받아 Action이 계속 돌아갔다.  

```csharp
private void ApplyMovement(Vector2 direction)
{
    direction = direction * characterStatHandler.CurrentStat.speed;
    if (controller.pause == true) direction *= 0f;
    movementRigidbody.velocity = direction;
}
```

플레이어를 관찰하는 옵저버 클래스로 가서 정지 시키는 코드를 만들어 주니 정상적으로 작동했다.



### 만든 사람들
:shipit: 김희환(팀장)||INTP	***[BlogTistory](https://mynameisreal.tistory.com/)***	**[깃허브 :rocket: ](https://github.com/kimihea)	**

:shipit: 손두혁(팀원)||ISFP	***[BlogTistory](https://hyukcoding.tistory.com/)***	**[깃허브 :airplane: ](https://github.com/engur88)	**



 
