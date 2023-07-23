using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class QuestConfiguratorController
    {
        private QuestObjectView _singleQuestView;
        private QuestController _singleQuestController;
        private QuestStoryConfig[] _questStoryConfigs;
        private QuestObjectView[] _storyQuestView;
        private QuestCoinModel _questCoinModel;

        private List<IQuestStory> _questStoryList;
        private InteractiveObjectView _player;

        private Dictionary<QuestType, Func<IQuestModel>> _questFactory = new Dictionary<QuestType, Func<IQuestModel>>(10);
        private Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>> _questStoryFactory = 
            new Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>>(10);

        public QuestConfiguratorController(QuestView QuestView, InteractiveObjectView player)
        {
            _singleQuestView = QuestView._singleQuest;
            _storyQuestView = QuestView._questObjects;
            _questStoryConfigs = QuestView._storyConfig;
            _questCoinModel = new QuestCoinModel();
            _player = player;
        }
        public void Start()
        {
            _singleQuestController = new QuestController(_player, _questCoinModel, _singleQuestView);
            _singleQuestController.Reset();

            _questFactory.Add(QuestType.Coins, () => new QuestCoinModel());
            _questStoryFactory.Add(QuestStoryType.Common, questCollection => new QuestStoryController(questCollection));

            _questStoryList = new List<IQuestStory>();

            foreach(QuestStoryConfig cfg in _questStoryConfigs)
            {
                _questStoryList.Add(CreateQuestStory(cfg));
            }
        }
        private IQuest CreateQuest(QuestConfig cfg)
        {
            int questID = cfg.id;
            QuestObjectView qView = _storyQuestView.FirstOrDefault(value => value._id == cfg.id);

            if(qView == null)
            {
                Debug.Log("No View");
                return null;
            }

            if(_questFactory.TryGetValue(cfg.type, out var factory))
            {
                IQuestModel qModel = factory.Invoke();
                return new QuestController(_player, qModel, qView);
            }
            Debug.Log("No Model");
            return null;
        }
        private IQuestStory CreateQuestStory(QuestStoryConfig cfg)
        {
            List<IQuest> quests = new List<IQuest>();

            foreach(QuestConfig item in cfg.questsConfig)
            {
                IQuest quest = CreateQuest(item);

                if (quest == null) continue;

                quests.Add(quest);
                Debug.Log("Add Quest");
            }

            return _questStoryFactory[cfg.type].Invoke(quests);
        }
    }
}