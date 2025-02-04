﻿using FickleFrameGames.Controllers.Internals;
using System;
using UnityEngine;


namespace FickleFrameGames.Controllers
{
    /// <summary>
    /// Base class of state, inherit this class to create custom states
    /// </summary>
    public abstract class State : ScriptableObject, IState
    {
        /*.............................................Serialized Fields....................................................*/

        [Header("-Base State Settings-")]
        [SerializeField] private EStateUpdateMode _updateMode = EStateUpdateMode.Update;

        /*.............................................Private Fields.......................................................*/

        private Action _stateUpdate = delegate { };
        private Action _stateFixedUpdate = delegate { };

        /*.............................................Properties...........................................................*/

        public Action OnStateUpdate { get { return _stateUpdate; } }
        public Action OnStateFixedUpdate { get { return _stateFixedUpdate; } }

        /*.............................................Private Methods......................................................*/

        /// <summary>
        /// Change the way how the state will be updated
        /// </summary>
        private void OnEnable()
        {
            if (_updateMode == EStateUpdateMode.Update)
                _stateUpdate = StateUpdate;
            else
                _stateFixedUpdate = StateUpdate;
        }

        /*.............................................Public Methods.......................................................*/

        /// <summary>
        /// Returns string corresponding to a state
        /// </summary>
        public abstract string GetState();


        /// <summary>
        /// State update logic
        /// </summary>
        public abstract void StateUpdate();
    }
}

